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
    //j2狀態可在10_search1.asp,查到好像少了一層sql要補 dub3 ss_apply
    j2 = "[{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("報名中") + "," + t1.QuotedStr("sno") + ":0},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("收訂報名中") + "," + t1.QuotedStr("sno") + ":1},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("已成團報名中") + "," + t1.QuotedStr("sno") + ":2},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("等待出發") + "," + t1.QuotedStr("sno") + ":3},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("已出發") + "," + t1.QuotedStr("sno") + ":4},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("'滿團") + "," + t1.QuotedStr("sno") + ":5},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("可候補") + "," + t1.QuotedStr("sno") + ":6},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("即將成團") + "," + t1.QuotedStr("sno") + ":7},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("滿團可候補") + "," + t1.QuotedStr("sno") + ":8}]";
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
    MssqlR t1 = new MssqlR();
    //Console.WriteLine(v01 + " " + v02 + " " + v03);
    //先取日期區間
    //轉成datatable 
    DataTable dt;
    DataTable dt1 = get_data["listarea"].ToObject<DataTable>();
    DataTable dt2 = get_data["listair"].ToObject<DataTable>();
    DataTable dt3 = get_data["listsign"].ToObject<DataTable>();
    //這蠻奇怪的,解json會有true及1所以要特別標註
    string vcsql1 = "";  //國家地區SQL
    string vcsql2 = "";  //航空公司
    string vcsql3 = "";  //狀態
    //string vcsql4="";  //關鍵字要考慮  
    foreach (DataRow xrec in dt1.Rows)
    {
        if ((xrec["ccc"].ToString() == "True") || (xrec["ccc"].ToString() == "1"))
        {
            if (vcsql1 == "")
            {
                vcsql1 = " and ((CONTENT_SUBITEM1.NNO=" + xrec["NNO"].ToString() + " and CONTENT_SUBITEM1.S_NNO=" + xrec["S_NNO"].ToString() + ")";
            }
            else
            {
                vcsql1 = vcsql1 + " or (CONTENT_SUBITEM1.NNO=" + xrec["NNO"].ToString() + " and CONTENT_SUBITEM1.S_NNO=" + xrec["S_NNO"].ToString() + ")";
            }
            //Console.WriteLine(xrec["S_NEWS_TITLE"] + " " + xrec["ccc"]);
        }
    }
    if (vcsql1 != "")
    {
        vcsql1 = vcsql1 + ")";       
    }
    foreach (DataRow xrec in dt2.Rows)
    {
        if ((xrec["ccc"].ToString() == "True") || (xrec["ccc"].ToString() == "1"))
        {
            if (vcsql2 == "")
            {
                vcsql2 = " and ((CONTENT_SSUBITEM3.SS_NEWS_TITLE='"+xrec["aname"]+"')";
            }
            else
            {
                vcsql2 = vcsql2 + " or (CONTENT_SSUBITEM3.SS_NEWS_TITLE='"+xrec["aname"]+"')";
            }
            //Console.WriteLine(xrec["aname"] + " " + xrec["ccc"]);
        }
    }
    if (vcsql2 != "")
    {
        vcsql2 = vcsql2 + ")";       
    }
    foreach (DataRow xrec in dt3.Rows)
    {
        if ((xrec["ccc"].ToString() == "True") || (xrec["ccc"].ToString() == "1"))
        {
             if (vcsql3 == "")
            {
                vcsql3 = " and ((CONTENT_SSUBITEM3.SS_APPLY="+xrec["sno"]+")";
            }
            else
            {
                vcsql3 = vcsql3 + " or (CONTENT_SSUBITEM3.SS_APPLY="+xrec["sno"]+")";
            }
            //Console.WriteLine(xrec["sname"] + " " + xrec["ccc"]);
        }
    }
    if (vcsql3 != "")
    {
        vcsql3 = vcsql3 + ")";       
    }   
    string s1 = string.Empty;    
    string vsql;
    vsql = "select CONTENT.NNO,";
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
    vsql = vsql + " LEFT JOIN CONTENT_SUBITEM1 on CONTENT.NNO=CONTENT_SUBITEM1.NNO";
    vsql = vsql + " where CONTENT_SUBITEM.S_MTYPE !=11  and CONTENT_SUBITEM.S_MTYPE !=36  and CONTENT_SUBITEM.S_MTYPE !=67  and CONTENT_SUBITEM.S_MTYPE !=79  and CONTENT_SUBITEM.S_MTYPE !=6 ";
    // CONTENT_SUBITEM.S_TTYPE=客製要注意
    //vsql = vsql + " where CONTENT_SUBITEM.S_MTYPE=4 ";
    //vsql=vsql+" and ( CONTENT_SSUBITEM3.SS_SUB_TITLE1 like '%七夕優惠%' or CONTENT_SSUBITEM3.SS_Reminder like '%七夕優惠%')"; 
    //vsql = vsql + " where CONTENT_SUBITEM.S_MTYPE =4";
    //vsql = vsql + " where 1=1";
    //SS_ADATE屬於DATETIME要做型別轉換   
    //vsql=vsql+" and CONTENT_SSUBITEM3.SS_ADATE>="+cast(t1.QuotedStr(v01)+" as datetime)"; 
    //vsql=vsql+" and CONTENT_SSUBITEM3.SS_ADATE<"+cast(t1.QuotedStr(v01)+" as datetime)";
    vsql = vsql + " and convert(nvarchar(10),CONTENT_SSUBITEM3.SS_ADATE,23)>='" + v01 + "'";
    vsql = vsql + " and convert(nvarchar(10),CONTENT_SSUBITEM3.SS_ADATE,23)<'" + v02 + "'";
    vsql = vsql + " and CONTENT.NEWS_DISPLAY=1 ";
    vsql = vsql + " and CONTENT.NNO=CONTENT_SUBITEM.NNO";
    vsql = vsql + " and ((CONTENT_SUBITEM.S_LDATE<=getdate() and CONTENT_SUBITEM.S_EDATE>=getdate()) or CONTENT_SUBITEM.S_AWON=1)";
    //vsql=vsql+" and CONTENT_SUBITEM.S_AWON=1";
    vsql = vsql + " and CONTENT_SUBITEM.S_NEWS_DISPLAY=1";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_ADATE>=getdate()";
    vsql = vsql + " and CONTENT_SUBITEM.S_NNO=CONTENT_SSUBITEM3.S_NNO";
    vsql = vsql + " and CONTENT_SSUBITEM3.SS_NEWS_DISPLAY=1";

    //附掛行程要討論
    vsql = vsql + " and CONTENT_SUBITEM.S_TTYPE = 0";
    //加入地區國家選擇
    if (vcsql1 != "")
    {
        vsql = vsql + vcsql1;
    }
    if (vcsql2 != "")
    {
        vsql = vsql + vcsql2;
    }
     if (vcsql3 != "")
    {
        vsql = vsql + vcsql3;
    }
    if (v03!="") {
        vsql=vsql+" and ( CONTENT_SSUBITEM3.SS_SUB_TITLE1 like '%"+v03+"%' or CONTENT_SSUBITEM3.SS_Reminder like '%"+v03+"%')";
    }
    
    //先測試所有的條件都要在此加入搜尋範圍
    vsql = vsql + " order by CONTENT_SSUBITEM3.SS_ADATE ASC";
    Console.WriteLine(vsql);
    dt = t1.RunSQL(vsql);
    s1 = JsonConvert.SerializeObject(dt);
    return s1;
});

app.Run();