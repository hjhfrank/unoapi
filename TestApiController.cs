using Models;
using Models.UNO;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IO;
using System.Web;
using PagedList;

namespace UNOTOUR.API
{
    
    [EnableCors(origins: "http://localhost:5173", headers: "*", methods: "*")]
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
        private string dot2rep(string S)
        {
            string s1, s2;
            int n1, n2;
            n1 = 0;
            n2 = S.Length - 1;
            s1 = "";
            while (n1 <= n2)
            {
                s2 = S.Substring(n1, 1);
                if (s2 == "-")
                {
                    s1 = s1 + ".";
                }
                else
                {
                    s1 = s1 + s2;
                }
                n1++;
            }
            return s1;
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
            string s1, jret;
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

        [HttpPost]
        [Route("API/listvvv2")]
        public string listvvv2([FromBody] JObject obj1)
        {
            string sno, vsql, s1;
            sno = obj1["sno"].ToString();
            DataTable dt;
            vsql = "SELECT PRODNAME,AIRLINE,STDATE,WEEKOF,T_DAY,SALES,VISAC,TAXC,TIPC,QTY,SIGNSTS,REM,SALENO,CRTDT,ALLID,URLPATH,URLPATH1";
            vsql += " FROM P02V";
            vsql += " WHERE SALENO='" + sno + "'";
            dt = RunSQL(vsql);
            s1 = JsonConvert.SerializeObject(dt);
            string jret = "{" + QuotedStr("dt") + ":" + s1 + "}";
            return jret;
        }

        [HttpPost]
        [Route("API/listvvv")]
        public string listvvv([FromBody] JObject obj1)
        {
          
            string v011, v012, v021, v022, v031, v032, v041, v042, v051, v052, v07, vsql, s1;
            string v061, v062, v063, v064, v065, v066, s2;
            int n1, n2, n3;
            v011 = obj1["v011"].ToString();
            v012 = obj1["v012"].ToString();
            v021 = obj1["v021"].ToString();
            v022 = obj1["v022"].ToString();
            v031 = obj1["v031"].ToString();
            v032 = obj1["v032"].ToString();
            v041 = obj1["v041"].ToString();
            v042 = obj1["v042"].ToString();
            v051 = obj1["v051"].ToString();    
            v052 = obj1["v052"].ToString();
            v061 = obj1["v061"].ToString();
            v062 = obj1["v062"].ToString();
            v063 = obj1["v063"].ToString();
            v064 = obj1["v064"].ToString();
            v065 = obj1["v065"].ToString();
            v066 = obj1["v066"].ToString();
            v07 = obj1["v07"].ToString();
            DataTable dt, dt1;            
            v011 = dot2rep(v011);
            v012 = dot2rep(v012);          
            vsql = "";          
            vsql += " SELECT PRODNAME,AIRLINE,STDATE,WEEKOF,T_DAY,SALES,VISAC,TAXC,TIPC,QTY,SIGNSTS,REM,SALENO,CRTDT,ALLID,URLPATH,URLPATH1";
            vsql += " FROM P02V";
            vsql += " where STDATE>='" + v011 + "' and STDATE<='" + v012 + "'";
            vsql += " and SALES>='" + v021 + "' and SALES<='" + v022 + "'";
            vsql += " and T_DAY>=" + v031 + " and T_DAY<=" + v032;
            vsql += " and AIRLINE>='" + v041 + "' and AIRLINE<='" + v042 + "'";
            s2 = "";
            if (v061 == "True")
            {
                if (s2 == "")
                {
                    s2 = "(SIGNSTS='報名')";
                }
                else
                {
                    s2 += " OR (SIGNSTS='報名')";
                }
            }
            if (v062 == "True")
            {
                if (s2 == "")
                {
                    s2 = "(SIGNSTS='候補')";
                }
                else
                {
                    s2 += " OR (SIGNSTS='候補')";
                }
            }
            if (v063 == "True")
            {
                if (s2 == "")
                {
                    s2 = "(SIGNSTS='即將成團')";
                }
                else
                {
                    s2 += " OR (SIGNSTS='即將成團')";
                }
            }
            if (v064 == "True")
            {
                if (s2 == "")
                {
                    s2 = "(SIGNSTS='已成團')";
                }
                else
                {
                    s2 += " OR (SIGNSTS='已成團')";
                }
            }
            if (v065 == "True")
            {
                if (s2 == "")
                {
                    s2 = "(SIGNSTS='保證出團')";
                }
                else
                {
                    s2 += " OR (SIGNSTS='保證出團')";
                }
            }
            if (v066 == "True")
            {
                if (s2 == "")
                {
                    s2 = "(SIGNSTS='結團')";
                }
                else
                {
                    s2 += " OR (SIGNSTS='結團')";
                }
            }
            if (s2 != "")
            {
                vsql = vsql + " and (" + s2 + ")";
            }
            string[] sa1;
            s2 = "";
            if (v07 != "")
            {
                sa1 = v07.Split(',');
                n1 = 0;
                n2 = sa1.Length - 1;
                while (n1 <= n2)
                {
                    s1 = sa1[n1];
                    if (n1 == 0)
                    {
                        s2 += " and ((PRODNAME LIKE '%" + s1 + "%')";
                    }
                    if ((n1 > 0) & (n1 < n2))
                    {
                        s2 += " or (PRODNAME LIKE '%" + s1 + "%')";
                    }
                    if (n1 == n2)
                    {
                        s2 += " or (PRODNAME LIKE '%" + s1 + "%'))";
                    }
                    n1++;
                }
                vsql += s2;
            }
          
            dt = RunSQL(vsql);
            dt1 = dt.Clone();
            DataRow r1;
            //把dt導入dt1    
            foreach (DataRow row in dt.Rows)
            {
                s1 = row["SALENO"].ToString();
                n2 = dt1.Rows.Count - 1;
                n1 = 0;
                n3 = 1;
                while (n1 <= n2)
                {
                    r1 = dt1.Rows[n1];
                    s2 = r1["SALENO"].ToString();
                    if (s1 == s2)
                    {
                        n3 = 0;
                        dt1.Rows.RemoveAt(n1);
                        dt1.ImportRow(row);
                        n1 = 99999;
                    }
                    n1++;
                }
                if (n3 == 1)
                {
                    dt1.ImportRow(row);
                }
            }
            s1 = JsonConvert.SerializeObject(dt1);
            string jret = "{" + QuotedStr("dt") + ":" + s1 + "}";
            return jret;
         
        }

        [HttpPost]
        [Route("API/listvvv1")]
        public string listvvv1([FromBody] JObject obj1)
        {
          
            string v01, vsql, s1, s2;
            int n1, n2, n3;
            v01 = obj1["v01"].ToString();
            DataTable dt, dt1;          
            string[] sa1;
            s2 = "";
            vsql = "";
            vsql = "SELECT PRODNAME,AIRLINE,STDATE,WEEKOF,T_DAY,SALES,VISAC,TAXC,TIPC,QTY,SIGNSTS,REM,SALENO,CRTDT,ALLID,URLPATH,URLPATH1";
            vsql += " FROM P02V";
            if (v01 != "")
            {
                sa1 = v01.Split(',');
                n1 = 0;
                n2 = sa1.Length - 1;
                while (n1 <= n2)
                {
                    s1 = sa1[n1];
                    if (n1 == 0)
                    {
                        s2 += " where ((PRODNAME LIKE '%" + s1 + "%')";
                    }
                    if ((n1 > 0) & (n1 < n2))
                    {
                        s2 += " or (PRODNAME LIKE '%" + s1 + "%')";
                    }
                    if (n1 == n2)
                    {
                        s2 += " or (PRODNAME LIKE '%" + s1 + "%'))";
                    }
                    n1++;
                }
                vsql += s2;
            }
            dt = RunSQL(vsql);
            dt1 = dt.Clone();
            DataRow r1;
            foreach (DataRow row in dt.Rows)
            {
                s1 = row["SALENO"].ToString();
                n2 = dt1.Rows.Count - 1;
                n1 = 0;
                n3 = 1;
                while (n1 <= n2)
                {
                    r1 = dt1.Rows[n1];
                    s2 = r1["SALENO"].ToString();
                    if (s1 == s2)
                    {
                        n3 = 0;
                        dt1.Rows.RemoveAt(n1);
                        dt1.ImportRow(row);
                        n1 = 99999;
                    }
                    n1++;
                }
                if (n3 == 1)
                {
                    dt1.ImportRow(row);
                }
            }
            n1 = dt.Rows.Count;
            n2 = dt1.Rows.Count;
            s1 = JsonConvert.SerializeObject(dt1);
            string jret = "{" + QuotedStr("dt") + ":" + s1 + "}";
            return jret;
        }
    }
}