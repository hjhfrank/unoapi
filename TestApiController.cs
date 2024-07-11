using Models;
using Models.UNO;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UNOTOUR.API
{
    public class TestApiController : ApiController
    {
        //private UNOContext db = new UNOContext();
        private string csn = ConfigurationManager.ConnectionStrings["DapperCn"].ConnectionString;
        
        private string QuotedStr(string S)
        {
            string vResult;
            vResult = S;
            for (int i = vResult.Length - 1; i >= 0; i--)
            {
                if (vResult[i].Equals('\''))
                {
                    vResult = vResult.Insert(i, "\'");
                }
            }
            vResult = '"' + vResult + '"';
            return vResult;
        }

        private DataTable RunSQL(string sSQL)
        {
            SqlConnection ct = new SqlConnection(csn);
            ct.Open();
            SqlCommand command = new SqlCommand(sSQL, ct);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            ct.Close();
            return dt;
        }

        private int RunSQLc(string sSQL)
        {
            int i = 0;
            SqlConnection ct = new SqlConnection(csn);
            ct.Open();
            SqlCommand command = new SqlCommand(sSQL, ct);
            i = command.ExecuteNonQuery();
            ct.Close();
            return i;
        }
        private string RunSQL_TRAN(List<string> sSQL)
        {
            //
            string msg = "ok";
            SqlConnection ct = new SqlConnection(csn);
            SqlCommand sqlWrite = ct.CreateCommand();
            ct.Open();
            SqlTransaction trans = ct.BeginTransaction();
            sqlWrite.Transaction = trans;
            try
            {
                foreach (string s1 in sSQL)
                {
                    sqlWrite.CommandText = s1;
                    sqlWrite.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                msg = "ng";
            }
            finally
            {
                ct.Close();
                sqlWrite.Dispose();
                ct.Dispose();
                trans.Dispose();
            }
            return msg;
        }

        [HttpGet]
        [Route("API/testapi")]
        public string testapi([FromBody] JObject obj1)
        {

            DataTable dt;
            string s1,jret;
            dt = RunSQL("select * from Area");
            s1 = JsonConvert.SerializeObject(dt);
            jret = "{" + QuotedStr("listarea") + ":" + s1 + "}";
            return jret;
        }

        [HttpPost]
        [Route("API/testapi1")]
        public string testapi1([FromBody] JObject obj1)
        {
            string s1 = obj1["somekey"].ToString();
            return s1;
        }
    }
 }