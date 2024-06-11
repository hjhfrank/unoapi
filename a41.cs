using System;
using System.Data;  
using Newtonsoft.Json;  
using Newtonsoft.Json.Linq;
using appsql;

namespace a41
{
    public class a411
    {
        public static void Map(WebApplication app)
        {
          app.MapPost("/x3", async (HttpRequest request) =>
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