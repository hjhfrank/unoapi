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
                                             .AllowAnyMethod(); ;
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
app.MapGet("/list1", () =>
{
    DataTable dt;
    string s1 = string.Empty;
    MssqlR t1 = new MssqlR();
    string vsql;
    vsql = "select a0.NNO,a0.CATEGORY,a0.NEWS_TITLE, a1.S_NEWS_TITLE, a1.S_NNO, a1.S_C_RANK,0 as ccc";
    vsql = vsql + " from CONTENT as a0 ";
    vsql = vsql + " LEFT JOIN CONTENT_SUBITEM1 as a1 ON a0.NNO = a1.NNO";
    vsql = vsql + " where";
    vsql = vsql + " a1.S_NEWS_DISPLAY=1";
    vsql = vsql + " and a0.NEWS_DISPLAY=1";
    vsql = vsql + " order by a0.CATEGORY,a0.nno,a1.S_C_RANK";
    dt = t1.RunSQL(vsql);
    s1 = JsonConvert.SerializeObject(dt);
    //為了將來能建檔,採用api下傳
    string j1, j2, jret;
    j1 = "[{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("長榮航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("中華航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("阿聯酋航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("土耳其航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("星宇航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("國泰航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("新加坡航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("日本航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("卡達航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("肯亞航空") + "},";
    j1 = j1 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("aname") + ":" + t1.QuotedStr("荷蘭皇家") + "}]";
    j2 = "[{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("報名中") + "},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("候補報名") + "},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("特惠團") + "},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("預購") + "},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("確定出團") + "},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("熱門團") + "}]";
    jret = "{" + t1.QuotedStr("listarea") + ":" + s1 + "," + t1.QuotedStr("listair") + ":" + j1 + "," + t1.QuotedStr("listsign") + ":" + j2 + "}";
    return jret;
});

app.MapPost("/list2", async (HttpRequest request) =>
{
    var body = new StreamReader(request.Body);
    string postData = await body.ReadToEndAsync();
    dynamic get_data = JObject.Parse(postData);
    string v01, v02, v03;
    v01 = get_data["v01"];
    v02 = get_data["v02"];
    v03 = get_data["keyw"];
    //Console.WriteLine(v01 + " " + v02 + " " + v03);
    //先取日期區間
    //轉成datatable 
    DataTable dt;
    DataTable dt1 = get_data["listarea"].ToObject<DataTable>();
    DataTable dt2 = get_data["listair"].ToObject<DataTable>();
    DataTable dt3 = get_data["listsign"].ToObject<DataTable>();
    //這蠻奇怪的,解json會有true及1所以要特別標註
    foreach (DataRow xrec in dt1.Rows)
    {
        if ((xrec["ccc"].ToString() == "True") || (xrec["ccc"].ToString() == "1"))
        {
            //Console.WriteLine(xrec["S_NEWS_TITLE"] + " " + xrec["ccc"]);
        }
    }
    foreach (DataRow xrec in dt2.Rows)
    {
        if ((xrec["ccc"].ToString() == "True") || (xrec["ccc"].ToString() == "1"))
        {
            //Console.WriteLine(xrec["aname"] + " " + xrec["ccc"]);
        }
    }
    foreach (DataRow xrec in dt3.Rows)
    {
        if ((xrec["ccc"].ToString() == "True") || (xrec["ccc"].ToString() == "1"))
        {
            //Console.WriteLine(xrec["sname"] + " " + xrec["ccc"]);
        }
    }
    string s1 = string.Empty;
    MssqlR t1 = new MssqlR();
    string vsql;
    vsql = "select top 100 CONTENT.NNO,";
    vsql = vsql + "CONTENT_SUBITEM.S_MTYPE,";
    vsql = vsql + "CONTENT.NEWS_TITLE,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEWS_TITLE,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Title,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Special,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Promotions,";
    vsql = vsql + "CONTENT_SUBITEM.S_NEW_Attach,";
    vsql = vsql + "CONTENT_SUBITEM.S_HORN,";
    vsql = vsql + "CONTENT_SUBITEM.S_DAY,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_NNO,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_TO,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_NEWS_TITLE,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_SUB_TITLE,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_SUB_TITLE1,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_SUB_TITLE2,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_Reminder,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_VORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_TORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_FORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_APPLY,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_PORN,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_TTYPE,";
    vsql = vsql + "CONTENT_SSUBITEM3.SS_ADATE";
    vsql = vsql + " FROM CONTENT_SUBITEM";
    vsql = vsql + " LEFT JOIN CONTENT on CONTENT.NNO=CONTENT_SUBITEM.NNO";
    vsql = vsql + " LEFT JOIN CONTENT_SSUBITEM3 on CONTENT.NNO=CONTENT_SUBITEM.NNO";
    //vsql = vsql + " where CONTENT_SUBITEM.S_MTYPE = 4";
    vsql = vsql + " where 1=1";
    //vsql=vsql+" and CONTENT_SSUBITEM3.SS_ADATE>="+v01; 
    //vsql=vsql+" and CONTENT_SSUBITEM3.SS_ADATE<"+v02;
    vsql = vsql + " and CONTENT.NEWS_DISPLAY=1 ";
    vsql = vsql + " and CONTENT.NNO=CONTENT_SUBITEM.NNO";
    //vsql = vsql + " and ((CONTENT_SUBITEM.S_LDATE<=getdate() and CONTENT_SUBITEM.S_EDATE>=getdate()) or CONTENT_SUBITEM.S_AWON=1)";
    vsql=vsql+" and CONTENT_SUBITEM.S_AWON=1";
    vsql = vsql + " and CONTENT_SUBITEM.S_NEWS_DISPLAY=1";
    //vsql = vsql + " and CONTENT_SSUBITEM3.SS_ADATE>=getdate()";
    vsql = vsql + " and CONTENT_SUBITEM.S_NNO=CONTENT_SSUBITEM3.S_NNO";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_NEWS_DISPLAY=1";       
    //先測試所有的條件都要在此加入搜尋範圍
    vsql = vsql + " order by CONTENT_SSUBITEM3.SS_ADATE ASC";
    dt = t1.RunSQL(vsql);
    s1 = JsonConvert.SerializeObject(dt);
    return s1;
});

app.Run();