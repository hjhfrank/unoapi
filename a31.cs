using System;
using System.Data;
using Newtonsoft.Json;  
using Newtonsoft.Json.Linq;
using appsql;

namespace a31
{
    /*
    public class st101sc 
    {
      [JsonPropertyName("id101")]
      public string id101  { get; set; }
      [JsonPropertyName("sec")]
      public string sec  { get; set; }
      [JsonPropertyName("prod_id")]
      public string prod_id { get; set; }
      [JsonPropertyName("prod_name")]
      public string prod_name { get; set; }
      [JsonPropertyName("qty")]
      public int qty { get; set; }
      [JsonPropertyName("price")]
      public int price { get; set; }
      [JsonPropertyName("tot")]
      public int tot { get; set; }
    }


    public class st101mc 
    {
      [JsonPropertyName("id101")]
      public string id101  { get; set; }
      [JsonPropertyName("cust_id")]
      public string cust_id  { get; set; }
      [JsonPropertyName("cust_name")]
      public string cust_name { get; set; }
      [JsonPropertyName("a_date")]
      public string a_date { get; set; }                
    }   

     
    public class St101 
    {       
      [JsonPropertyName("msg")]
      public string msg { get; set; }
      [JsonPropertyName("st101m")]
      public st101mc[] st101m { get; set; }
      [JsonPropertyName("st101s")]
      public st101sc[] st101s { get; set; }
    } 
    */  
    
    public class a311
    {
        public static void Map(WebApplication app)
        {
          app.MapPost("/login", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();           
            dynamic jo1 = JObject.Parse(postData);  
            string s1=string.Empty;
            string v1,v2,v3;              
            PssqlR t1=new PssqlR();      
            v1=jo1["userid"];                                 
            v2=jo1["userpassword"];  
            if (t1.Chk_Login(v1,v2)==true)
            {         
              v3=t1.InsertUKey(v1);               
              if (v3=="Error") 
              {                                    
                s1=@"{""msg"":""ng"",""vkey"":""ng"",""userid"":"+t1.QuotedStr(v1)+"}";	
              }                          
              else
              {    
                s1="{"+t1.QuotedStr("msg")+":"+t1.QuotedStr("ok")+",";
                s1=s1+t1.QuotedStr("vkey")+":"+t1.QuotedStr(v3)+",";
                s1=s1+t1.QuotedStr("userid")+":"+t1.QuotedStr(v1)+"}";                 
              }
            }
            else
            {               
               s1=@"{""msg"":""ng"",""vkey"":""ng"",""userid"":"+t1.QuotedStr(v1)+"}";	                                        
            }
            return s1;
          });

          app.MapPost("/prods", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();   
            dynamic get_data = JObject.Parse(postData);                    
            string userkey;
            string s1="{[]}"; 
            userkey=get_data["userkey"];
            PssqlR t1=new PssqlR();
            DataTable dt;                    
            if (t1.getUserKey(userkey)==true)    
            {              
              dt=t1.RunSQL("select prod_id,prod_name from prod order by prod_id;");                			
              s1=JsonConvert.SerializeObject(dt);                
            }
            return s1;
          });  

          app.MapPost("/prodss", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey,sprod_id;
            string s1="{[]}"; 
            PssqlR t1=new PssqlR();
            DataTable dt;             
            userkey=get_data["userkey"];                    
            sprod_id=get_data["sprod_id"]+'%';             
            if (t1.getUserKey(userkey)==true) 
            {
              dt=t1.RunSQL("select prod_id,prod_name from prod where prod_id like '"+sprod_id+"' order by prod_id;");                			
              s1=JsonConvert.SerializeObject(dt);    
            }                            
            return s1;                    
          });  

          app.MapPost("/st101data", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();           
            dynamic get_data = JObject.Parse(postData);  
            string userkey,sid101,sbtn_no,sdt1,sdt2,s1;
            PssqlR t1=new PssqlR();
            DataTable dt1,dt2; 
            userkey=get_data["userkey"];                                
            sid101=get_data["sid101"];            
            sbtn_no=get_data["btn_no"];                           
            if (t1.getUserKey(userkey)==true)    
            {      
              sid101=t1.get_pkeyv("id101","st101m",sid101,sbtn_no);     
              dt1=t1.RunSQL("select id101,a_date,cust_id,cust_name,to_date(a_date,'YYYYMMDD') v_date from st101m where id101='"+sid101+"';");   
              dt2=t1.RunSQL("select id101,sec,prod_id,prod_name,qty,price,tot from st101s where id101='"+sid101+"' order by id101,sec;");
              sdt1=JsonConvert.SerializeObject(dt1);	
              sdt2=JsonConvert.SerializeObject(dt2);	
              s1="{"+t1.QuotedStr("msg")+":"+t1.QuotedStr("ok")+",";
              s1=s1+t1.QuotedStr("st101m")+":"+sdt1+",";
              s1=s1+t1.QuotedStr("st101s")+":"+sdt2+"}";             
            } 
            else
            {
              s1="{"+t1.QuotedStr("msg")+":"+t1.QuotedStr("ok")+",";
              s1=s1+t1.QuotedStr("st101m")+":[{}],";
              s1=s1+t1.QuotedStr("st101s")+":[{}]}";  
            }  
            return s1;                  
          });  

          app.MapPost("/custss", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey,scust_id;
            string s1="{[]}"; 
            PssqlR t1=new PssqlR();
            DataTable dt;             
            userkey=get_data["userkey"];                    
            scust_id=get_data["scust_id"]+'%';             
            if (t1.getUserKey(userkey)==true) 
            {
              dt=t1.RunSQL("select cust_id,cust_name from cust where cust_id like '"+scust_id+"' order by cust_id;");                			
              s1=JsonConvert.SerializeObject(dt);    
            }                            
            return s1;                    
          });  

          app.MapPost("/custs", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey;
            string s1="{[]}"; 
            PssqlR t1=new PssqlR();
            DataTable dt;             
            userkey=get_data["userkey"];                                         
            if (t1.getUserKey(userkey)==true) 
            {
              dt=t1.RunSQL("select cust_id,cust_name from cust order by cust_id");                			
              s1=JsonConvert.SerializeObject(dt);   
              s1="{"+t1.QuotedStr("msg")+":"+t1.QuotedStr("ok")+",";
              s1=s1+t1.QuotedStr("custs")+":"+s1+"}";                
            } 
            else
            {
              s1="{"+t1.QuotedStr("msg")+":"+t1.QuotedStr("ng")+",";
              s1=s1+t1.QuotedStr("custs")+":[]}";       
            }                           
            return s1;                    
          });  

          app.MapPost("/custs1", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey;
            string s1="{[]}"; 
            PssqlR t1=new PssqlR();
            DataTable dt;             
            userkey=get_data["userkey"];                                         
            if (t1.getUserKey(userkey)==true) 
            {
              dt=t1.RunSQL("select cust_id,cust_name from cust order by cust_id");                			
              s1=JsonConvert.SerializeObject(dt);                              
            }                          
            return s1;                    
          });  

          app.MapPost("/prodcrud", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey,prod_id,prod_name,smode,smsg,vsql;
            int price;
            string s1,s2;
            PssqlR t1=new PssqlR();           
            List<string> sSQL=new List<string>();           
            userkey=get_data["userkey"];    
            prod_id=get_data["prod_id"];  
            prod_name=get_data["prod_name"];  
            price=get_data["price"];  
            smode=get_data["smode"];
            smsg="ok";                                       
            vsql="";
            s1="{'msg':'ng'}";
            if (t1.getUserKey(userkey)==true) 
            {
              if (smode=="append") 
              {
                vsql="insert into prod (prod_id,prod_name,price) values ('"+prod_id+"','"+prod_name+"',"+price.ToString()+");";
              }
              if (smode=="edit") 
              {
                vsql="update prod set prod_name='"+prod_name+",price="+price.ToString()+" where prod_id='"+prod_id+"';";                           
              }
              if (smode=="dele") 
              {
                vsql="delete from prod where prod_id='"+prod_id+"';";                           
              }
              sSQL.Add(vsql);
              s2=t1.RunSQL_TRAN(sSQL); 
              if (s2=="ok")
              {
                 s1="{'msg':'ok'}";
              }
            }                          
            return s1;                    
          });           

          app.MapPost("/custcrud", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey,cust_id,cust_name,smode,smsg,vsql;            
            string s1,s2;
            PssqlR t1=new PssqlR();           
            List<string> sSQL=new List<string>();           
            userkey=get_data["userkey"];    
            cust_id=get_data["cust_id"];  
            cust_name=get_data["cust_name"];             
            smode=get_data["smode"];
            smsg="ok";                                       
            vsql="";
            s1="{'msg':'ng'}";
            if (t1.getUserKey(userkey)==true) 
            {
              if (smode=="append") 
              {
                vsql="insert into cust (cust_id,cust_name) values ('"+cust_id+"','"+cust_name+"');";
              }
              if (smode=="edit") 
              {
                vsql="update cust set cust_name='"+cust_name+" where cust_id='"+cust_id+"';";                           
              }
              if (smode=="dele") 
              {
                vsql="delete from cust where cust_id='"+cust_id+"';";                           
              }
              sSQL.Add(vsql);
              s2=t1.RunSQL_TRAN(sSQL); 
              if (s2=="ok")
              {
                 s1="{'msg':'ok'}";
              }
            }                          
            return s1;                    
          });           

          app.MapPost("/st101dele", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey,sid101;            
            string s1,s2;
            PssqlR t1=new PssqlR();           
            List<string> sSQL=new List<string>();           
            userkey=get_data["userkey"];    
            sid101=get_data["id101"];             
            s1="{'ServerMsg':'ng'}";
            if (t1.getUserKey(userkey)==true) 
            {              
              sSQL.Add("delete from st101m where id101='"+sid101+"';");
              sSQL.Add("delete from st101s where id101='"+sid101+"';");
              s2=t1.RunSQL_TRAN(sSQL); 
              if (s2=="ok")
              {
                 s1="{'ServerMsg':'ok'}";
              }
            }                          
            return s1;                    
          });           

          app.MapPost("/st101crud", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();                        
            dynamic get_data = JObject.Parse(postData);  
            string userkey,vsql;           
            string s1,s2,sid101,sid101v;
            string fmt = "00000000.##";
            int sid101i;         
            JObject jo1 = get_data["st101m"].ToObject<JObject>(); 
            DataTable dt2 = get_data["st101s"].ToObject<DataTable>();
            DataTable dt3;
            PssqlR t1=new PssqlR();           
            List<string> sSQL=new List<string>();           
            userkey=get_data["userkey"];               
            s1="{'ServerMsg':'ng'}";
            if (t1.getUserKey(userkey)==true) 
            { 
              sid101=jo1["id101"].ToString();
              if (sid101=="新增單號") 
              {
                 vsql="select cnt from auto_num where prg_id='test'";
                 dt3=t1.RunSQL(vsql);
                 sid101i=Convert.ToInt32(dt3.Rows[0][0].ToString())+1;
                 sid101v="SA"+string.Format("{0:d8}",sid101i);
                 vsql="update auto_num set cnt=cnt+1 where prg_id='test';";
                 sSQL.Add(vsql);
                 vsql="insert into st101m (id101,a_date,cust_id,cust_name) values ('";
                 vsql=vsql+sid101v+"','"+jo1["a_date"]+"','"+jo1["cust_id"]+"','"+jo1["cust_name"]+"');";
                 sSQL.Add(vsql);  
                 sid101=sid101v;               
              }
              else
              {
                 vsql="update st101m set a_date='"+jo1["a_date"]+"',cust_id='"+jo1["cust_id"];
                 vsql=vsql+"',cust_name='"+jo1["cust_name"]+"' where id101='"+sid101+"'";
                 sSQL.Add(vsql);
                 vsql="delete from st101s where id101='"+sid101+"'";
                 sSQL.Add(vsql);
              }              
              foreach (DataRow r1 in dt2.Rows)
              {
                  vsql="insert into st101s (id101,sec,prod_id,prod_name,qty,price,tot) values ('"+sid101+"','";
                  //vsql=vsql+r1["sec"].ToString()+"','"+r1["prod_id"].ToString()+"','"+r1["prod_name"].ToString()+"',"+r1["qty"].ToString()+","+r1["price"].ToString()+","+r1["tot"].ToString()+");";
                  vsql=vsql+r1["sec"]+"','"+r1["prod_id"]+"','"+r1["prod_name"]+"',"+r1["qty"]+","+r1["price"].ToString()+","+r1["tot"]+");";
                  sSQL.Add(vsql);
              }              
              s2=t1.RunSQL_TRAN(sSQL); 
              if (s2=="ok")
              {
                 s1="{'ServerMsg':'ok'}";
              }
            }                          
            return s1;                    
          });        
          
          app.MapPost("/x1", async (HttpRequest request) =>
          {
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();           
            dynamic jo1 = JObject.Parse(postData);          
            DataTable dtm = jo1["st101m"].ToObject<DataTable>();
            DataTable dts = jo1["st101s"].ToObject<DataTable>();      
            //Console.WriteLine(postData);                             
            return "{'status':'ok'}";
          });

          app.MapPost("/x2", async (HttpRequest request) =>
          {            
            var body = new StreamReader(request.Body);
            string postData = await body.ReadToEndAsync();           
            dynamic jo1 = JObject.Parse(postData);                             
            PssqlR t1=new PssqlR();
            DataTable dt;
            dt=t1.RunSQL("select prod_id,prod_name from prod order by prod_id;");
            string s1=string.Empty;  			
            s1 = JsonConvert.SerializeObject(dt);			
            s1=@"{""msg"":""ok"",""prods"":"+s1+"}";			
            return s1;              
          });

        }
    }
    
}