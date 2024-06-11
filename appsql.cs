using System;
using System.Data;
using Newtonsoft.Json;   
using Npgsql;


/*
  RunSQLc針對1條語句，應該是隱含交易功能，不建議使用
  RunSQL_TRAN明確交易處理
  很奇怪postgresql只接受'不接受"
*/

namespace appsql
{
    class PssqlR
    {
        private string connectionString ="Host=192.168.1.10;Port=5432;Username=postgres;Password=hjhjack;Database=testdb";                  

        public string QuotedStr(string S)
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

        public DataTable RunSQL(string sSQL)
        {                               
            NpgsqlConnection ct = new NpgsqlConnection(connectionString);                                     
            ct.Open();              
            NpgsqlCommand command = new NpgsqlCommand(sSQL,ct);
            NpgsqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();                                
            dt.Load(reader);
            ct.Close();                                             
            return dt;
        }    

        public int RunSQLc(string sSQL)
        {                               
            int i;
            NpgsqlConnection ct = new NpgsqlConnection(connectionString);                                     
            ct.Open();              
            NpgsqlCommand command = new NpgsqlCommand(sSQL,ct);
            i=command.ExecuteNonQuery();           
            ct.Close();                                             
            return i;
        }   

        public string RunSQL_TRAN(List<string> sSQL)
        {
            string msg="ok";         
            NpgsqlConnection ct = new NpgsqlConnection(connectionString);                                     
            ct.Open(); 
            NpgsqlCommand sqlWrite = ct.CreateCommand();                    
            NpgsqlTransaction trans = ct.BeginTransaction();
            sqlWrite.Transaction = trans;           
            try
            {
              foreach (string s1 in sSQL)
              {               
                sqlWrite.CommandText =s1;
                //Console.WriteLine(s1);    
                sqlWrite.ExecuteNonQuery();
              }                
              trans.Commit();                      
            }
            catch (Exception ex)
            {                   
               trans.Rollback();
               msg="ng";
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

        public bool Chk_Login(string v1,string v2)
        {
            DataTable dt;            
            dt=RunSQL("SELECT userid from webuser where userid='"+v1+"' and userpass='"+v2+"'");           
            if (dt.Rows.Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool chkUOneKey(string v1,string v2)
        {
            DataTable dt;
            dt=RunSQL("select allid from usertoken where vdate='"+v1+"' and skey='"+v2+"'");                      
            if (dt.Rows.Count>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string InsertUKey(string v1)
        {            
            DateTime s2 = DateTime.Now;
            string s1=s2.ToString("yyyyMMdd");
            string s3,vsql,s4;           
            List<string> sSQL=new List<string>();
            var random = new Random();
            int i,j;
            i=1;
            s3="";
            while (i<=10)
            {
                j=random.Next(10, 256);
                s3=s3+Convert.ToString(j,16);
                i++;
            }
            vsql="delete from usertoken where vdate='"+s1+"' and userid='"+v1+"';";   
            sSQL.Add(vsql);          
            vsql="insert into usertoken(vdate,userid,skey) values ('"+s1+"','"+v1+"','"+s3+"');";
            sSQL.Add(vsql); 
            //Console.WriteLine(sSQL.Count);    
            s4=RunSQL_TRAN(sSQL);            
            if (s4=="ng") { s3="Error"; }             
            return s3;
        }

        public string get_pkeyv(string v1,string v2,string v3,string v4)
        {
            string vsql;
            DataTable dt;
            vsql="select "+v1+" from "+v2;    
            if (v4=="01") { vsql=vsql+" where "+v1+"=(select min("+v1+") from "+v2+");"; }             
            if (v4=="02") { vsql=vsql+" where "+v1+"=(select max("+v1+") from "+v2+" where "+v1+"<'"+v3+"');"; }
            if (v4=="03") { vsql=vsql+" where "+v1+"=(select min("+v1+") from "+v2+" where "+v1+">'"+v3+"');";}    
            if (v4=="04") { vsql=vsql+" where "+v1+"=(select max("+v1+") from "+v2+")"; } 
            dt=RunSQL(vsql);   
            return dt.Rows[0][0].ToString();
        }
           
        public bool getUserKey(string v1)
        {
          DateTime s2 = DateTime.Now;
          string s1=s2.ToString("yyyyMMdd");          
          DataTable dt;
          dt=RunSQL("select allid from usertoken where vdate='"+s1+"' and skey='"+v1+"';");  
          if (dt.Rows.Count>0)
          {
              return true;
          }
          else
          {
              return false;
          }

        }
    }
}    
