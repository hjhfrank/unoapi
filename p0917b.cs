using OpenQA.Selenium;  
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading.Tasks;
using System.Threading;
using apmssql;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.Arm;
//using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices.ComTypes;


namespace SeleniumTest
{
    class Program
    {
        //原本想採用PYTHON來爬,後來改用C#來排好進資料庫
        //python不用sleep c#要不過各有利弊                    
       
       
            static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);
            int npp= Int32.Parse(args[0]);

            //先爬鳳凰旅行社,鳳凰只有1條歐洲線其他不考慮
            MssqlR t1 = new MssqlR();
            DataTable dt,dtv;
            string vsql;
            vsql = "SELECT ALLID,URLPATH FROM P01V";
            dt = t1.RunSQL(vsql);
            //IWebDriver driver = new ChromeDriver();
            int n1, n2,n3,n4,n5,n6,l1;
            n1 = 7;
            n2 = dt.Rows.Count - 1;
            n1 = npp;
            n2 =npp;
            n3 = 0;
            n4 = 0;
            n5 = 0;
            n6 = 0;
            l1 = 0;
            List<string> aa1 = new List<string>();
            List<string> aa2 = new List<string>();           
            List<string> aa3 = new List<string>();
            List<string> aa4 = new List<string>();
            List<string> aa5 = new List<string>();
            List<string> aa6 = new List<string>();
            List<string> asql = new List<string>();
            string s1, s2, s3, s4,s99;
            string s02, s03, s04;
            string s11, s12, s13, s14, s15,s16,s17,s18,s19,s20;
            string s21, s22, s23, s24,s25;
            string s31, s32,s33;
            while (n1 <= n2)
            {
                //IWebDriver driver = new ChromeDriver();
                IWebDriver driver = new FirefoxDriver();
                s1 = dt.Rows[n1]["ALLID"].ToString();
                s2 = dt.Rows[n1]["URLPATH"].ToString();
                //Console.WriteLine(s1 + s2);
                //s2 = "https://www.travel.com.tw/TOU/TOU0010/24EUE10DMMCH%5E24EUE10DMM%5E24EUE10DFF/EOE010110BR25A";
                s32 = s2;
                s33 = s2;
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
                //c#只接受一個class name,要判斷是否有這個class否則會當機
                Console.WriteLine(n1);
                n5 = 0;
                n6 = aa1.Count - 1;
                l1 = -1;
                while (n5<=n6)
                {
                    s02=aa1[n5];
                    if (s02.IndexOf("table-hover") > 0)
                    {
                        n5 = 10000;
                        l1 = 0;
                    }                        
                    n5++;
                }
                if (l1 == 0)
                {
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
                    int np1, np2;
                    np1 = 0;
                    np2 = 0;
                    aa3.Clear();
                    s31 = aa2[0];
                    s03 = s31.Substring(0, s31.IndexOf(' '));
                    s31 = s03;
                    //這樣抓會有問題
                    n3 = 0;
                    n4 = aa1.Count - 1;
                    while (n3 <= n4)
                    {
                        s02 = aa1[n3];
                        if ((s02.IndexOf(s31) > 0) & (s02.IndexOf("<a href=") > 0))
                        {
                            if (np1 == 0)
                            {
                                np1 = n3 - 2;
                            }

                        }
                        if (((s02.IndexOf("</tbody>") >= 0)) & (np1 > 0) & (np2 == 0))

                        {
                            np2 = n3 - 2;
                            n3 = 10000;
                        }
                        n3++;
                    }
                    n3 = np1;
                    n4 = np2;
                    while (n3 <= n4)
                    {
                        s02 = aa1[n3];
                        if (s02 != "")
                        {
                            aa3.Add(s02);
                        }
                        n3++;
                    }
                    n3 = 0;
                    n4 = aa3.Count - 1;

                    //s31 = (n1 + 1000).ToString();
                    //s31 = "a3" + s31 + ".txt";             
                    //using (StreamWriter sw = File.CreateText(s31))
                    using (StreamWriter sw = File.CreateText("3.txt"))
                    {
                        n3 = 0;
                        n4 = aa3.Count - 1;
                        while (n3 <= n4)
                        {
                            s02 = aa3[n3];
                            if ((s02.IndexOf("<td") >= 0) & (s02.IndexOf("</td>") < 0))
                            {
                                s02 = aa3[n3] + aa3[n3 + 1] + "</td>";
                                n3 = n3 + 2;
                            }
                            if (s02 != "")
                            {
                                if (s02.IndexOf("</tr>") < 0)
                                {
                                    sw.WriteLine(s02.Trim());
                                }
                            }
                            n3++;
                        }
                    }
                }
                //找到規律了,3.txt 每15行1條
              
                driver.Close();
                driver.Quit();
                aa3.Clear();
                asql.Clear();
                //代表有資料
                if (l1==0)
                {
                    using (StreamReader sr = new StreamReader("3.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {                            
                            aa3.Add(line); 
                        }
                    }
                    n5 = 0;
                    n6 = ((aa3.Count + 1) / 15) - 1;;
                    while (n5 <= n6)
                    {
                        s31= aa3[n5*15+2];
                        s32 = s31.Substring(13);
                        s31= s32.Trim();                        
                        s32 = s31.Substring(0, s31.Length - 9);
                        s11 = s32;
                        s99 = s32;
                        s32 = s11.Substring(0, s11.IndexOf('>')-1);
                        s12 = s11.Substring(s11.IndexOf('>') + 1);
                        s99 = s12;
                        s11 = s31 = aa3[n5 * 15 + 3];
                        s13 = s11.Substring(4, s11.IndexOf("/td>") - 5);                        
                        s11 = s31 = aa3[n5 * 15 + 4];
                        s14 = s11.Substring(4, s11.IndexOf("/td>") - 5);
                        s11 = s31 = aa3[n5 * 15 + 5];
                        s15 = s11.Substring(4, s11.IndexOf("/td>") - 5);
                        s11 = s31 = aa3[n5 * 15 + 6];
                        s16 = s11.Substring(4, s11.IndexOf("/td>") - 5);                     
                        s11 = s31 = aa3[n5 * 15 + 7];
                        s17 = s11.Substring(4, s11.IndexOf("/td>") - 5);
                        if (s17.IndexOf("<a href=") >= 0)
                        {
                            s11 = s17.Substring(20);
                            s17 = s11.Substring(s11.IndexOf(">") + 1);
                            s17 = s17.Substring(0, s17.Length - 4);
                        }                      
                        s11 = s31 = aa3[n5 * 15 + 8];
                        s18 = s11.Substring(4, s11.IndexOf("/td>") - 5);                      
                        s11 = s31 = aa3[n5 * 15 + 9];
                        s19 = s11.Substring(4, s11.IndexOf("/td>") - 5);
                        s11 = s31 = aa3[n5 * 15 + 10];
                        s20 = s11.Substring(4, s11.IndexOf("/td>") - 5);
                        s11 = s31 = aa3[n5 * 15 + 11];
                        s21 = s11.Substring(4, s11.IndexOf("/td>") - 5);
                        s21 = s21.Trim();                      
                        s11 = aa3[n5 * 15 + 12];
                        s22 = s11.Substring(4, s11.IndexOf("/td>") - 5);                      
                        s11 = s22;
                        s22 = s11.Substring(s11.IndexOf("</button>") - 20);                      
                        s11 = s22;
                        s22 = s11.Substring(s11.IndexOf(">")+1);
                        s11 = s22;
                        s22 = s11.Substring(0,s11.IndexOf("<"));
                        s11 = aa3[n5 * 15 + 13];
                        s23 = s11.Substring(4, s11.IndexOf("/td>") - 5);                                            
                        s23= s23.Trim();
                        if (s23!="")
                        {
                            s11 = s23;
                            s23=s11.Substring(s11.IndexOf(">")+1);
                        }
                        vsql = "insert into P02V (URLPATH,URLPATH1,PRODNAME,AIRLINE,STDATE,WEEKOF,T_DAY,SALES,VISAC,TAXC,TIPC, QTY,";
                        vsql = vsql + "SIGNSTS,REM,SALENO,ISALES,IQTY) values (";
                        //vsql = vsql + t1.QuotedStr("") + ",";
                        vsql = vsql + t1.QuotedStr(s33) + ",";
                        vsql = vsql + t1.QuotedStr("https://www.travel.com.tw/" + s32) + ",";
                        vsql = vsql + t1.QuotedStr(s99) + ",";
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
                        vsql = vsql + t1.QuotedStr(s32) + ",0,0);";
                        asql.Add(vsql);
                        n5++;
                    }
                    if (asql.Count > 0)
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

                n1++;
            }              
        }
    }
}