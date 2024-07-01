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
    //vsql = "select a0.NNO,a0.CATEGORY,a0.NEWS_TITLE, a1.S_NEWS_TITLE, a1.S_NNO, a1.S_C_RANK,0 as ccc";
    //vsql = vsql + " from CONTENT as a0 ";
    //vsql = vsql + " LEFT JOIN CONTENT_SUBITEM1 as a1 ON a0.NNO = a1.NNO";
    //vsql = vsql + " where";
    //vsql = vsql + " a1.S_NEWS_DISPLAY=1";
    //vsql = vsql + " and a0.NEWS_DISPLAY=1";
    //vsql = vsql + " order by a0.CATEGORY,a0.nno,a1.S_C_RANK";
    vsql = "";
    vsql += "SELECT ";
    vsql += "cat.ID,";
    vsql += "cat.CID,";
    vsql += "cat.Name,";
    vsql += "cont.NNO,";
    vsql += "cont.CATEGORY,";
    vsql += "cont.NEWS_TITLE,";
    vsql += "sub1.S_NNO,";
    vsql += "sub1.NNO,";
    vsql += "sub1.S_NEWS_TITLE,";
    vsql += "0 as ccc";
    vsql += " FROM CONTENT_SUBITEM1 AS sub1";
    vsql += " INNER JOIN CONTENT AS cont ON sub1.NNO = cont.NNO";
    vsql += " INNER JOIN U_Category AS cat ON cont.CATEGORY = cat.CID";
    vsql += " WHERE";
    vsql += " sub1.S_NEWS_DISPLAY = 1";
    vsql += " AND cont.NEWS_DISPLAY = 1";
    vsql += " AND cat.Status = 1";
    vsql += " ORDER BY";
    vsql += " cat.Sort ASC,";
    vsql += " cont.C_RANK ASC,";
    vsql += " sub1.S_C_RANK ASC";
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
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("收訂中") + "," + t1.QuotedStr("sno") + ":1},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("已成團") + "," + t1.QuotedStr("sno") + ":2},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("等出發") + "," + t1.QuotedStr("sno") + ":3},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("已出發") + "," + t1.QuotedStr("sno") + ":4},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("滿團") + "," + t1.QuotedStr("sno") + ":5},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("可候補") + "," + t1.QuotedStr("sno") + ":6},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("即將成團") + "," + t1.QuotedStr("sno") + ":7},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("滿團可候補") + "," + t1.QuotedStr("sno") + ":8},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("額滿") + "," + t1.QuotedStr("sno") + ":9}]";
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
    foreach (DataRow xrec in dt1.Rows)
    {
        if ((xrec["ccc"].ToString() == "True") || (xrec["ccc"].ToString() == "1"))
        {
            if (vcsql1 == "")
            {
                vcsql1 = " and ((sub1.NNO=" + xrec["NNO"].ToString() + " and sub1.S_NNO=" + xrec["S_NNO"].ToString() + ")";
            }
            else
            {
                vcsql1 = vcsql1 + " or (sub1.NNO=" + xrec["NNO"].ToString() + " and sub1.S_NNO=" + xrec["S_NNO"].ToString() + ")";
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
                vcsql2 = " and ((ssub3.SS_NEWS_TITLE='" + xrec["aname"] + "')";
            }
            else
            {
                vcsql2 = vcsql2 + " or (ssub3.SS_NEWS_TITLE='" + xrec["aname"] + "')";
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
                vcsql3 = " and ((ssub3.SS_APPLY=" + xrec["sno"] + ")";
            }
            else
            {
                vcsql3 = vcsql3 + " or (ssub3.SS_APPLY=" + xrec["sno"] + ")";
            }
            //Console.WriteLine(xrec["sname"] + " " + xrec["ccc"]);
        }
    }
    if (vcsql3 != "")
    {
        vcsql3 = vcsql3 + ")";
    }   
    //asp的關鍵字切割,用,分開陣列,先不要這麼麻煩,只針對欄位,先保留
    //if (v03!="") 
    //{
    //}
    string s1 = string.Empty;
    string vsql;
    vsql = "SELECT ";
    vsql += "cat.CID,";
    vsql += "cat.Name,";
    vsql += "cont.NNO,";
    vsql += "cont.CATEGORY,";
    vsql += "cont.NEWS_TITLE,";
    vsql += "sub1.S_NNO,";
    vsql += "sub1.NNO,";
    vsql += "sub1.S_NEWS_TITLE,";
    vsql += "sub.S_NNO,";
    vsql += "sub.S_MTYPE,";
    vsql += "sub.S_NNO_UNDER,";
    vsql += "sub.S_NEWS_TITLE,";
    vsql += "sub.S_NEW_Title,";
    vsql += "sub.S_NEW_Special,";
    vsql += "sub.S_NEW_Promotions,";
    vsql += "sub.S_NEW_Attach,";
    vsql += "sub.S_HORN,";
    vsql += "sub.S_DAY,";
    vsql += "ssub3.SS_NNO,";
    vsql += "ssub3.SS_ADATE,";
    vsql += "ssub3.SS_TO,";
    vsql += "ssub3.SS_TTYPE,";
    vsql += "ssub3.SS_NEWS_TITLE,";
    vsql += "ssub3.SS_SUB_TITLE,";
    vsql += "ssub3.SS_SUB_TITLE1,";
    vsql += "ssub3.SS_SUB_TITLE2,";
    vsql += "ssub3.SS_Reminder,";
    vsql += "ssub3.SS_VORN,";
    vsql += "ssub3.SS_TORN,";
    vsql += "ssub3.SS_FORN,";
    vsql += "ssub3.SS_APPLY,";
    vsql += "ssub3.SS_PORN,";
    vsql += "ssub3.SS_NNO,";
    vsql += "ssub3.SS_ADATE,";
    vsql += "ssub3.SS_TO,";
    vsql += "ssub3.SS_TTYPE,";
    vsql += "ssub3.SS_NEWS_TITLE,";
    vsql += "ssub3.SS_SUB_TITLE,";
    vsql += "ssub3.SS_SUB_TITLE1,";
    vsql += "ssub3.SS_SUB_TITLE2,";
    vsql += "ssub3.SS_Reminder,";
    vsql += "ssub3.SS_VORN,";
    vsql += "ssub3.SS_TORN,";
    vsql += "ssub3.SS_FORN,";
    vsql += "ssub3.SS_APPLY,";
    vsql += "ssub3.SS_PORN,";
    vsql += "sub2.S_NNO AS Sub2_S_NNO,";
    vsql += "sub2.S_NEWS_TITLE AS Sub2_S_NEWS_TITLE,";
    vsql += "sub2.S_NEW_Title AS Sub2_S_NEW_Title,";
    vsql += "sub2.S_NEW_Special AS Sub2_S_NEW_Special,";
    vsql += "sub2.S_NEW_Promotions AS Sub2_S_NEW_Promotions,";
    vsql += "sub2.S_NEW_Attach AS Sub2_S_NEW_Attach,";
    vsql += "sub2.S_HORN AS Sub2_S_HORN,";
    vsql += "sub2.S_DAY AS Sub2_S_DAY";
    vsql += " FROM CONTENT_SSUBITEM3 AS ssub3";
    vsql += " INNER JOIN CONTENT_SUBITEM AS sub ON ssub3.S_NNO = sub.S_NNO";
    vsql += " INNER JOIN CONTENT_SUBITEM1 AS sub1 ON sub.S_MTYPE = sub1.S_NNO";
    vsql += " INNER JOIN CONTENT AS cont ON sub1.NNO = cont.NNO";
    vsql += " INNER JOIN U_Category AS cat ON cont.CATEGORY = cat.CID";
    vsql += " LEFT JOIN CONTENT_SUBITEM AS sub2 ON ssub3.SS_TO = sub2.S_NNO";
    vsql += " WHERE";
    //日期區間,很怪,直下sql沒問題,但是在c#要轉換    
    vsql = vsql + " convert(varchar(10),ssub3.SS_ADATE,23)>='" + v01 + "'";
    vsql = vsql + " AND convert(varchar(10),ssub3.SS_ADATE,23)<'" + v02 + "'";
    //很多table都有NEWS_DISPLAY欄位,須為1才是生效
    vsql = vsql + " AND cont.NEWS_DISPLAY = 1";
    //判斷產品是否有效
    vsql = vsql + " AND ((sub.S_LDATE <= getdate() AND sub.S_EDATE >= getdate()) OR sub.S_AWON=1)";
    vsql = vsql + " AND sub.S_NEWS_DISPLAY = 1 AND ssub3.SS_ADATE >= getdate() AND ssub3.SS_NEWS_DISPLAY=1";
    //加入地區國家選擇
    if (vcsql1 != "")
    {
        vsql = vsql + vcsql1;
    }
    //航空公司
    if (vcsql2 != "")
    {
        vsql = vsql + vcsql2;
    }
    //狀態
    if (vcsql3 != "")
    {
        vsql = vsql + vcsql3;
    }
    //這段是keyword,和asp寫得有些不一樣,先保留,看是否要像asp一樣,keyword取消改用tag
    //if (v03!="") {
    //    vsql=vsql+" and ( CONTENT_SSUBITEM3.SS_SUB_TITLE1 like '%"+v03+"%' or CONTENT_SSUBITEM3.SS_Reminder like '%"+v03+"%')";
    //}       
    vsql = vsql + " ORDER BY ssub3.SS_ADATE ASC";
    Console.WriteLine(vsql);
    dt = t1.RunSQL(vsql);
    s1 = JsonConvert.SerializeObject(dt);
    return s1;
});


//配合asp berfor srearch一個api全部回傳
app.MapGet("/listx", () =>
{
    DataTable dt, dt1;
    string s1 = string.Empty;
    string s2 = string.Empty;
    MssqlR t1 = new MssqlR();
    string vsql;
    vsql = "select NNO, NEWS_TITLE from CONTENT where CATEGORY != 0 AND NEWS_DISPLAY=1 ORDER BY C_RANK ASC";
    dt = t1.RunSQL(vsql);
    s1 = JsonConvert.SerializeObject(dt);
    //這段sql採用CTE比較少見,但可以用 SQL 2005以後皆可使用,幾乎所有流行db都有支援
    vsql = "WITH AREACTE (SEC,NNO,NEWS_TITLE)";
    vsql += " AS";
    vsql += " (";
    vsql += "  SELECT ROW_NUMBER() OVER(ORDER BY C_RANK ASC) AS SEC,NNO, NEWS_TITLE from CONTENT where CATEGORY != 0 AND NEWS_DISPLAY=1 ";
    vsql += " )";
    vsql += " SELECT BB.SEC,AA.S_NNO,AA.NNO,AA.S_NEWS_TITLE ,AA.S_C_RANK";
    vsql += " FROM CONTENT_SUBITEM1 AA";
    vsql += " LEFT JOIN AREACTE BB ON AA.NNO=BB.NNO";
    vsql += " WHERE AA.S_NEWS_DISPLAY = 1";
    vsql += "   AND BB.SEC IS NOT NULL";
    vsql += " ORDER BY BB.SEC,AA.NNO,AA.S_C_RANK";
    //Console.WriteLine(vsql);
    dt1 = t1.RunSQL(vsql);
    s2 = JsonConvert.SerializeObject(dt1);
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
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("收訂中") + "," + t1.QuotedStr("sno") + ":1},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("已成團") + "," + t1.QuotedStr("sno") + ":2},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("等出發") + "," + t1.QuotedStr("sno") + ":3},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("已出發") + "," + t1.QuotedStr("sno") + ":4},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("滿團") + "," + t1.QuotedStr("sno") + ":5},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("可候補") + "," + t1.QuotedStr("sno") + ":6},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("即將成團") + "," + t1.QuotedStr("sno") + ":7},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("滿團可候補") + "," + t1.QuotedStr("sno") + ":8},";
    j2 = j2 + "{" + t1.QuotedStr("ccc") + ":0," + t1.QuotedStr("sname") + ":" + t1.QuotedStr("額滿") + "," + t1.QuotedStr("sno") + ":9}]";
    jret = "{" + t1.QuotedStr("listarea") + ":" + s1 + "," + t1.QuotedStr("listc") + ":" + s2 + "," + t1.QuotedStr("listair") + ":" + j1 + "," + t1.QuotedStr("listsign") + ":" + j2 + "}";
    return jret;
});

app.MapPost("/listx1", async (HttpRequest request) =>
{
    var body = new StreamReader(request.Body);
    string postData = await body.ReadToEndAsync();
    dynamic get_data = JObject.Parse(postData);
    //post上來的全都是字串
    string sdate, edate, area, mtype, airline, apply, searchword, s1, vsqlc;
    sdate = get_data["sdate"];
    edate = get_data["edate"];
    area = get_data["area"];
    mtype = get_data["mtype"];
    airline = get_data["airline"];
    apply = get_data["apply"];
    searchword = get_data["searchword"];
    vsqlc = " and ";   
    //先加起訖日期,這個要注意        
    vsqlc += " convert(varchar(10),ssub3.SS_ADATE,23)>='" + sdate + "' and ";
    vsqlc += " convert(varchar(10),ssub3.SS_ADATE,23)<'" + edate + "' and ";
    if (area != "")
    {
        vsqlc += "cont.NNO=" + area + " and ";
    }
    if (airline!="")
    {
         vsqlc+=" ssub3.SS_NEWS_TITLE='" + airline + "' and ";
    }
    if (apply!="")
    {
         //vsqlc+=" ssub3.SS_NEWS_TITLE='" + airline + "' and ";         
         vsqlc+=" ssub3.SS_APPLY=" + apply + " and ";
    }
    //vsqlc+=" 1=0 and ";
    string vsql;
    //這邊要解釋下,INNER JOIN和LEFT JOIN差別在此
    //這個針對SQL SERVER特別有效    
    //inner join 假設a為表頭筆數,b為表身筆數
    //以表單為例
    //inner join要處理的點為a*b筆
    //反過來說以b為中心,left join處理點只有b筆,left join完勝
    vsql = "select ";
    vsql += "cat.CID, ";
    vsql += "cat.Name, ";
    vsql += "cont.NNO, ";
    vsql += "cont.CATEGORY,  ";
    vsql += "cont.NEWS_TITLE, ";
    vsql += "sub1.S_NNO, ";
    vsql += "sub1.NNO, ";
    vsql += "sub1.S_NEWS_TITLE, ";
    vsql += "sub.S_NNO, ";
    vsql += "sub.S_MTYPE, ";
    vsql += "sub.S_NNO_UNDER, ";
    vsql += "sub.S_NEWS_TITLE, ";
    vsql += "sub.S_NEW_Title,";
    vsql += "sub.S_NEW_Special,";
    vsql += "sub.S_NEW_Promotions,";
    vsql += "sub.S_NEW_Attach,";
    vsql += "sub.S_HORN, ";
    vsql += "sub.S_DAY, ";
    vsql += "ssub3.SS_NNO, ";
    vsql += "ssub3.SS_ADATE,  ";
    vsql += "ssub3.SS_TO, ";
    vsql += "ssub3.SS_TTYPE, ";
    vsql += "ssub3.SS_NEWS_TITLE, ";
    vsql += "ssub3.SS_SUB_TITLE, ";
    vsql += "ssub3.SS_SUB_TITLE1, ";
    vsql += "ssub3.SS_SUB_TITLE2, ";
    vsql += "ssub3.SS_Reminder, ";
    vsql += "ssub3.SS_VORN, ";
    vsql += "ssub3.SS_TORN, ";
    vsql += "ssub3.SS_FORN, ";
    vsql += "ssub3.SS_APPLY, ";
    vsql += "ssub3.SS_PORN, ";
    vsql += "ssub3.SS_HORN, ";
    vsql += "sub2.S_NNO AS Sub2_S_NNO, ";
    vsql += "sub2.S_NEWS_TITLE AS Sub2_S_NEWS_TITLE, ";
    vsql += "sub2.S_NEW_Title AS Sub2_S_NEW_Title, ";
    vsql += "sub2.S_NEW_Special AS Sub2_S_NEW_Special, ";
    vsql += "sub2.S_NEW_Promotions AS Sub2_S_NEW_Promotions, ";
    vsql += "sub2.S_NEW_Attach AS Sub2_S_NEW_Attach, ";
    vsql += "sub2.S_HORN AS Sub2_S_HORN, ";
    vsql += "sub2.S_DAY AS Sub2_S_DAY ";
    vsql += "from CONTENT_SSUBITEM3 as ssub3 ";
    //vsql += "INNER JOIN CONTENT_SUBITEM AS sub ON ssub3.S_NNO = sub.S_NNO  ";
    //vsql += "INNER JOIN CONTENT_SUBITEM1 AS sub1 ON sub.S_MTYPE = sub1.S_NNO  ";
    //vsql += "INNER JOIN CONTENT AS cont ON sub1.NNO = cont.NNO  ";
    //vsql += "INNER JOIN U_Category AS cat ON cont.CATEGORY = cat.CID  ";
    vsql += "LEFT JOIN CONTENT_SUBITEM AS sub ON ssub3.S_NNO = sub.S_NNO  ";
    vsql += "LEFT JOIN CONTENT_SUBITEM1 AS sub1 ON sub.S_MTYPE = sub1.S_NNO  ";
    vsql += "LEFT JOIN CONTENT AS cont ON sub1.NNO = cont.NNO  ";
    vsql += "LEFT JOIN U_Category AS cat ON cont.CATEGORY = cat.CID  ";
    vsql += "LEFT JOIN CONTENT_SUBITEM AS sub2 ON ssub3.SS_TO = sub2.S_NNO ";
    vsql += "where ssub3.SS_ADATE >= getdate() ";
    //限制條件在此加
    vsql += vsqlc;
    vsql += " ((sub.S_LDATE <= getdate() and sub.S_EDATE >= getdate()) or sub.S_AWON = 1) ";
    vsql += "and ssub3.SS_NEWS_DISPLAY = 1  ";
    vsql += "and sub.S_NEWS_DISPLAY = 1   ";
    vsql += "and sub1.S_NEWS_DISPLAY = 1  ";
    vsql += "and cont.NEWS_DISPLAY = 1  ";
    vsql += "and cat.Status = 1  ";
    vsql += "order by ssub3.SS_ADATE ASC";
    //Console.WriteLine(vsql);
    MssqlR t1 = new MssqlR();
    DataTable dt;
    dt = t1.RunSQL(vsql);
    s1 = JsonConvert.SerializeObject(dt);
    string jret = "{" + t1.QuotedStr("msg") + ":0," + t1.QuotedStr("dt") + ":" + s1 + "}";
    return jret;
});

app.Run();