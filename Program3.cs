using System;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using apmssql;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500",
                                             "http://127.0.0.1",
                                             "http://localhost:5500")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();;
                      });
});

var app = builder.Build();
//開固定port
//app.Urls.Add("https://localhost:3000");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/", () => "Hello World!");
//get使用parameter會有問題,暴露參數,改用post較安全
app.MapGet("/test",async (HttpRequest request) =>{          
    var body = new StreamReader(request.Body);
    string postData = await body.ReadToEndAsync();          
    //Console.WriteLine(request);
    //Console.WriteLine(body);
    Console.WriteLine("a:"+postData);
    //dynamic jo1 = JObject.Parse(postData);      
    //Console.Write(jo1);
    DataTable dt;
    string s1 = string.Empty;
    MssqlR t1 = new MssqlR();
    string vsql;
    //這段是原始查詢結果,要加工查詢,net不給過,全段可能要重理,20240617改用left join
    vsql = "select CONTENT.NEWS_TITLE,CONTENT_SUBITEM.S_NEWS_TITLE,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Title,CONTENT_SUBITEM.S_NEW_Special,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Promotions,CONTENT_SUBITEM.S_NEW_Attach,CONTENT_SUBITEM.S_HORN,";
    vsql = vsql + "CONTENT_SUBITEM.S_DAY,CONTENT_SSUBITEM3.SS_NNO,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_TO,CONTENT_SSUBITEM3.SS_NEWS_TITLE,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_SUB_TITLE,CONTENT_SSUBITEM3.SS_SUB_TITLE1,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_SUB_TITLE2,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_Reminder,CONTENT_SSUBITEM3.SS_VORN,CONTENT_SSUBITEM3.SS_TORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_FORN,CONTENT_SSUBITEM3.SS_APPLY,CONTENT_SSUBITEM3.SS_PORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_TTYPE,CONTENT_SSUBITEM3.SS_ADATE";
    vsql = vsql + " FROM CONTENT_SUBITEM";
    vsql = vsql + " LEFT JOIN CONTENT on CONTENT.NNO=CONTENT_SUBITEM.NNO and CONTENT.NEWS_DISPLAY=1";
    vsql = vsql + " LEFT JOIN CONTENT_SSUBITEM3 on CONTENT.NNO=CONTENT_SUBITEM.NNO";
    //所有的條件都需要在此下sql and判斷
    vsql = vsql + " where CONTENT_SSUBITEM3.SS_ADATE>='2024-07-15'";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_ADATE<'2024-10-16'";
    vsql = vsql + " and (CONTENT_SSUBITEM3.SS_SUB_TITLE1 like '%七夕優惠%' or CONTENT_SSUBITEM3.SS_Reminder like '%七夕優惠%')";
    //vsql = vsql + " and CONTENT.NEWS_DISPLAY=1";
    //vsql = vsql + " and CONTENT.NNO=CONTENT_SUBITEM.NNO";
    vsql = vsql + " and ((CONTENT_SUBITEM.S_LDATE<=getdate() and CONTENT_SUBITEM.S_EDATE>=getdate()) or CONTENT_SUBITEM.S_AWON=1)";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=11";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=36";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=67";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=79";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=6";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=7";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=48";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=119";
    vsql = vsql + " and CONTENT_SUBITEM.S_NEWS_DISPLAY=1";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_ADATE>=getdate()";
    vsql = vsql + " and CONTENT_SUBITEM.S_NNO=CONTENT_SSUBITEM3.S_NNO";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_NEWS_DISPLAY=1";
    vsql = vsql + " order by CONTENT_SSUBITEM3.SS_ADATE ASC";
    //vsql = vsql + "";
    //dt = t1.RunSQL(vsql"select NEWS_CONTENT,NEWS_DISPLAY from EDM_CONTENT where NNO=4 or NNO=5 order by NNO ASC");
    dt=t1.RunSQL(vsql);

    s1 = JsonConvert.SerializeObject(dt);
    return s1;
});

app.MapPost("/test1",async (HttpRequest request) =>
{  
    var body = new StreamReader(request.Body);
    string postData = await body.ReadToEndAsync();      
    Console.WriteLine("a:"+postData);
    DataTable dt;
    string s1 = string.Empty;
    MssqlR t1 = new MssqlR();
    string vsql;
    //這段是原始查詢結果,要加工查詢,net不給過,全段可能要重理,20240617改用left join
    vsql = "select CONTENT.NEWS_TITLE,CONTENT_SUBITEM.S_NEWS_TITLE,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Title,CONTENT_SUBITEM.S_NEW_Special,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Promotions,CONTENT_SUBITEM.S_NEW_Attach,CONTENT_SUBITEM.S_HORN,";
    vsql = vsql + "CONTENT_SUBITEM.S_DAY,CONTENT_SSUBITEM3.SS_NNO,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_TO,CONTENT_SSUBITEM3.SS_NEWS_TITLE,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_SUB_TITLE,CONTENT_SSUBITEM3.SS_SUB_TITLE1,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_SUB_TITLE2,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_Reminder,CONTENT_SSUBITEM3.SS_VORN,CONTENT_SSUBITEM3.SS_TORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_FORN,CONTENT_SSUBITEM3.SS_APPLY,CONTENT_SSUBITEM3.SS_PORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_TTYPE,CONTENT_SSUBITEM3.SS_ADATE";
    vsql = vsql + " FROM CONTENT_SUBITEM";
    vsql = vsql + " LEFT JOIN CONTENT on CONTENT.NNO=CONTENT_SUBITEM.NNO and CONTENT.NEWS_DISPLAY=1";
    vsql = vsql + " LEFT JOIN CONTENT_SSUBITEM3 on CONTENT.NNO=CONTENT_SUBITEM.NNO";
    //所有的條件都需要在此下sql and判斷
    vsql = vsql + " where CONTENT_SSUBITEM3.SS_ADATE>='2024-07-15'";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_ADATE<'2024-10-16'";
    vsql = vsql + " and (CONTENT_SSUBITEM3.SS_SUB_TITLE1 like '%七夕優惠%' or CONTENT_SSUBITEM3.SS_Reminder like '%七夕優惠%')";
    //vsql = vsql + " and CONTENT.NEWS_DISPLAY=1";
    //vsql = vsql + " and CONTENT.NNO=CONTENT_SUBITEM.NNO";
    vsql = vsql + " and ((CONTENT_SUBITEM.S_LDATE<=getdate() and CONTENT_SUBITEM.S_EDATE>=getdate()) or CONTENT_SUBITEM.S_AWON=1)";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=11";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=36";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=67";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=79";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=6";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=7";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=48";
    vsql = vsql + " and CONTENT_SUBITEM.S_MTYPE !=119";
    vsql = vsql + " and CONTENT_SUBITEM.S_NEWS_DISPLAY=1";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_ADATE>=getdate()";
    vsql = vsql + " and CONTENT_SUBITEM.S_NNO=CONTENT_SSUBITEM3.S_NNO";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_NEWS_DISPLAY=1";
    vsql = vsql + " order by CONTENT_SSUBITEM3.SS_ADATE ASC";
    //vsql = vsql + "";
    //dt = t1.RunSQL(vsql"select NEWS_CONTENT,NEWS_DISPLAY from EDM_CONTENT where NNO=4 or NNO=5 order by NNO ASC");
    dt=t1.RunSQL(vsql);
    s1 = JsonConvert.SerializeObject(dt);
    return s1;
});

app.Run();