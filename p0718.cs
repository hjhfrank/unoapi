using OpenQA.Selenium;  
using OpenQA.Selenium.Chrome;  
using System;
using System.Threading.Tasks;
using System.Threading;
using apmssql;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.Arm;


namespace SeleniumTest
{
    class Program
    {
        //原本想採用PYTHON來爬,後來改用C#來排好進資料庫
        //python不用sleep c#要不過各有利弊                    
       
       
            static void Main(string[] args)
        {
            //先爬鳳凰旅行社,鳳凰只有1條歐洲線其他不考慮
            MssqlR t1 = new MssqlR();
            DataTable dt;
            string vsql;
            vsql = "SELECT ALLID,URLPATH FROM P01V";
            dt = t1.RunSQL(vsql);
            //IWebDriver driver = new ChromeDriver();
            int n1, n2,n3,n4,n5,n6;
            n1 = 0;
            n2 = dt.Rows.Count - 1;
            n3 = 0;
            n4 = 0;
            n5 = 0;
            n6 = 0; 
            List<string> aa1 = new List<string>();
            List<string> aa2 = new List<string>();           
            List<string> aa3 = new List<string>();
            List<string> aa4 = new List<string>();
            List<string> aa5 = new List<string>();
            List<string> aa6 = new List<string>();
            List<string> asql = new List<string>();
            string s1, s2, s3, s4;
            string s02, s03, s04;
            string s11, s12, s13, s14, s15,s16,s17,s18,s19,s20;
            string s21, s22, s23, s24,s25;
            string s31, s32;
            while (n1 <= n2) {                 
                IWebDriver driver = new ChromeDriver();
                s1 = dt.Rows[n1]["ALLID"].ToString();
                s2 = dt.Rows[n1]["URLPATH"].ToString();
                s32 = s2;
                driver.Navigate().GoToUrl(s2);            
                driver.Manage().Window.Maximize();
                Thread.Sleep(5000);
                s3 = driver.PageSource;                
                using (StreamWriter sw = File.CreateText("1.txt"))
                {
                    sw.WriteLine(s3);
                }
                using (StreamReader sr = new StreamReader("1.txt"))
                {
                    //aa1 = sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {                       
                       aa1.Add(line);                          
                    }
                }               
                //c#只接受一個class name
                s4 = driver.FindElement(By.ClassName("table-hover")).Text;
                using (StreamWriter sw = File.CreateText("2.txt"))
                {
                    sw.WriteLine(s4);
                }
                using (StreamReader sr = new StreamReader("2.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        { aa2.Add(line); }
                    }
                }             
                aa3.Clear();
                foreach (string s01 in aa2)
                {
                    s03 = s01.Substring(0, s01.IndexOf(' '));
                    s04= s01.Substring(s01.IndexOf(" ")+1);
                    s04 = s04.Substring(s04.IndexOf(" ")+1);
                    s04 = s04.Substring(0,s04.IndexOf(" "));                                 
                    n3 = 0;
                    n4 = aa1.Count - 1;                
                    while (n3<=n4)
                    {
                        s02 = aa1[n3];                       
                        if (s02.IndexOf(s03) >= 0)
                        {
                            s11 = aa1[n3 + 1];
                            s12 = aa1[n3 + 2];
                            s13 = aa1[n3 + 3];
                            s14 = aa1[n3 + 4];
                            s15 = aa1[n3 + 5];
                            if ((s11.IndexOf(s04) >= 0) || (s12.IndexOf(s04) >= 0) || (s13.IndexOf(s04) >= 0) || (s14.IndexOf(s04) >= 0) || (s15.IndexOf(s04) >= 0))
                            {
                                s11 = s02.Substring(s02.IndexOf('"')+1);
                                s11 = s11.Substring(0,s11.IndexOf('"'));
                                s2 = "https://www.travel.com.tw/" + s11;
                                /*
                                driver.Navigate().GoToUrl(s2);
                                driver.Manage().Window.Maximize();
                                Thread.Sleep(5000);
                                s3 = driver.PageSource;
                                using (StreamWriter sw = File.CreateText("4.txt"))
                                {
                                  sw.WriteLine(s3);
                                }
                                aa5.Clear();
                                using (StreamReader sr = new StreamReader("4.txt"))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (line != "")
                                        { aa5.Add(line); }
                                    }
                                }
                                n5 = 0;
                                n6 = aa5.Count - 1;
                                while (n5<=n6) 
                                {
                                    s21 = aa5[n5];  
                                    if (s21.IndexOf("商品代號：")>=0)
                                    {
                                        s11 = aa5[n5+1];
                                        //s12 = aa5[n5 + 2];
                                        //s13 = aa5[n5 + 3];
                                        //s14 = aa5[n5 + 4];
                                        //s15 = aa5[n5 + 5];
                                        if (s11!="")
                                        {
                                            if (s11.IndexOf("p") < 0)
                                            {                                       
                                                Console.WriteLine(s11); 
                                                aa6.Add(s11);
                                                n5 = 100000;
                                            }
                                        }
                                        /*
                                        if (s12 != "")
                                        {
                                            if (s12.IndexOf("p") < 0)
                                            {
                                                Console.WriteLine(s12 + " 2");
                                                aa6.Add(s12);
                                                n5 = 100000;
                                            }
                                        }
                                        if (s13 != "")
                                        {
                                            if (s11.IndexOf("p") < 0)
                                            {
                                                aa6.Add(s13);
                                                Console.WriteLine(s13 + " 3");
                                                n5 = 100000;
                                            }
                                        }
                                        if (s14 != "")
                                        {
                                            if (s11.IndexOf("p") < 0)
                                            {
                                                aa6.Add(s14);
                                                Console.WriteLine(s14 + " 4");
                                                n5 = 100000;
                                            }
                                        }
                                        if (s15 != "")
                                        {
                                            if (s11.IndexOf("p") < 0)
                                            {
                                                aa6.Add(s15);
                                                Console.WriteLine(s15+" 5");
                                                n5 = 100000;
                                            }
                                        }
                                        
                                    }
                                    n5++; 
                                }       
                                */
                                aa3.Add(s11);
                                n3 = 9999;
                            }
                        }
                        n3++;
                    }
                }
                //aa3
                using (StreamWriter sw = File.CreateText("3.txt"))
                {
                    foreach (string s01 in aa3)
                    {
                        sw.WriteLine(s01);
                    }
                }                
                driver.Close();
                driver.Quit();
                //在這裡insert 資料庫
                aa1.Clear();    
                aa2.Clear();               
                using (StreamReader sr = new StreamReader("2.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        { aa1.Add(line); }
                    }
                }
                using (StreamReader sr = new StreamReader("3.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        { aa2.Add(line); }
                    }
                }
                n3 = 0;
                n4 = aa1.Count - 1;
                while (n3 <= n4)
                {
                    s11 = aa1[n3];
                    s12 = s11.Substring(0, s11.IndexOf(' '));
                    s13 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s13;
                    s13 = s11.Substring(0, s11.IndexOf(' '));
                    s14 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s14;
                    s14 = s11.Substring(0, s11.IndexOf(' '));
                    s15 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s15;
                    s15 = s11.Substring(0, s11.IndexOf(' '));
                    s16 = s11.Substring(s11.IndexOf(' ') + 1);
                    s11 = s16;
                    s16 = s11.Substring(0, s11.IndexOf(' '));
                    s17 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s17;
                    s17 = s11.Substring(0, s11.IndexOf(' '));
                    s18 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s18;
                    s18 = s11.Substring(0, s11.IndexOf(' '));
                    s19 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s19;
                    s19 = s11.Substring(0, s11.IndexOf(' '));
                    s20 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s20;
                    s20 = s11.Substring(0, s11.IndexOf(' '));
                    s21 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s21;
                    s21 = s11.Substring(0, s11.IndexOf(' '));
                    s22 = s11.Substring(s11.IndexOf(" ") + 1);
                    s11 = s22;
                    s23 = s11;
                    s31 = aa2[n3];
                    n5 = s17.IndexOf(",");
                    if (n5 >= 0)
                    {
                        s25 = s17.Substring(0, n5 - 1) + s17.Substring(n5 + 1);
                    }
                    else 
                    {
                        s25 = s17;  
                    }
                    vsql = "insert into P02V (URLPATH,URLPATH1,PRODNAME,AIRLINE,STDATE,WEEKOF,T_DAY,SALES,VISAC,TAXC,TIPC, QTY,";
                    vsql = vsql + "SIGNSTS,REM,SALENO,ISALES,IQTY) values (";
                    //vsql = vsql + t1.QuotedStr("") + ",";
                    vsql = vsql + t1.QuotedStr("https://www.travel.com.tw/"+s31)+ ",";
                    vsql = vsql + t1.QuotedStr("https://www.travel.com.tw/" + s32) + ",";
                    vsql = vsql + t1.QuotedStr(s12)+  ",";
                    vsql = vsql + t1.QuotedStr(s13) + ",";
                    vsql = vsql + t1.QuotedStr(s14) + ",";
                    vsql = vsql + t1.QuotedStr(s15) + ",";
                    vsql = vsql + t1.QuotedStr(s16) + ",";
                    vsql = vsql + t1.QuotedStr(s17) + ",";
                    vsql = vsql + t1.QuotedStr(s18) + ",";
                    vsql = vsql + t1.QuotedStr(s19) + ",";
                    vsql = vsql + t1.QuotedStr(s20) + ",";
                    vsql = vsql + t1.QuotedStr(s21) + ",";                    
                    vsql = vsql + t1.QuotedStr(s22) + ",";
                    vsql = vsql + t1.QuotedStr(s23) + ",";
                    vsql = vsql + t1.QuotedStr(s31) + ","+s25+","+s21+");";
                    asql.Add(vsql);                 
                    n3++;
                }
                n1++;
            }
            if (asql.Count>0)
            {
                using (StreamWriter sw = File.CreateText("01.SQL"))
                {
                    foreach (string s01 in asql)
                    {
                        sw.WriteLine(s01);
                    }
                }
                s31 = t1.RunSQL_TRAN(asql);
               Console.WriteLine(s31);
            }
        }
    }
}