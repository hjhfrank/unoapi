create table usertoken (
   allid  int NOT NULL AUTO_INCREMENT,
   vdate1 varchar(8),
   vdate2 datetime default now(),
   userid int,  
   skey   varchar(20),   
primary key(allid),UNIQUE KEY(skey));

create table webuser (
  allid    int NOT NULL AUTO_INCREMENT,
  username varchar(40) NOT NULL,
  userpass varchar(40) NOT NULL,
  userpath varchar(20) NOT NULL, 
  usermail varchar(100) NOT NULL, 
  usertel varchar(20) default '', 
  userreuser int Default 0, 
  useraddr varchar(200) Default '', 
  utext1  varchar(400) Default '', 
  utext2  varchar(10) Default '', 
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  vdate3  datetime default now(), 
  age     int   default 19,
  cost1   int   default 0,
  mcost1  int   default 0,
  cost2   int   default 0,
  mcost2  int   default 0,
  oc1     int   default 0,
  oc2     int   default 0,
  va1     int   default 0,
  va2     varchar(20) Default '',
  udate   varchar(10),
  id01    varchar(1) Default '0',
  id02    varchar(1) Default '0',
  id03    varchar(1) Default '0',
  id04    varchar(1) Default '0',
primary key(allid),UNIQUE KEY(userpath),UNIQUE KEY(usermail));

create table webcrt (
  allid   int NOT NULL AUTO_INCREMENT,
  userid  int, 
  pic1    blob,
  pic2    blob,
  pic3    blob,  
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  id01    varchar(1) Default '0',
  id02    varchar(1) Default '0',
primary key(allid)); 

create table upbat (  
  allid   int NOT NULL AUTO_INCREMENT,
  absfile varchar(200) Default '',
  upfile  varchar(200) Default '',   
  dsfile  varchar(200) Default '',
  bsfile  varchar(200) Default '',
  extname varchar(10) Default '',
  stype   varchar(3) Default '',
  hostna  varchar(40) Default 'http://192.168.1.13:8000',
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  vdate3  datetime default now(),
  utext1  varchar(400) Default '', 
  utext2  varchar(100) Default '', 
  userid  int Default 0,
  cost1   int default 0,
  cost2   int default 0, 
  vpost1  varchar(1),
  vpost2  varchar(20),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',  
primary key(allid)); 

create table upbatx (  
  allid   int NOT NULL AUTO_INCREMENT,  
  sec     int,
  absfile varchar(200),
  upfile  varchar(200),       
  stype   varchar(3),  
  vdate1  datetime default now(), 
  upbat   int Default 0,      
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',
primary key(allid),UNIQUE KEY(upbat,sec)); 

create table upbat1 (  
  allid   int NOT NULL AUTO_INCREMENT,
  upbat   int,
  userid  int,   
  vdate1  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',   
primary key(allid)); 

create table upbat2 (  
  allid   int NOT NULL AUTO_INCREMENT,
  upbat   int,
  userid  int,   
  utext   varchar(200) not null,  
  vdate1  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table sale1 (  
  allid   int NOT NULL AUTO_INCREMENT,
  userid1 int,
  userid2 int,   
  sdate   varchar(8),
  edate   varchar(8),
  cost1   int,
  cost2   int,   
  vdate1  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table sale2 (  
  allid   int NOT NULL AUTO_INCREMENT,
  upbat   int,
  userid1 int,
  userid2 int,       
  cost1   int,
  cost2   int,   
  vdate1  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table sale3 (  
  allid   int NOT NULL AUTO_INCREMENT,  
  userid  int,         
  buyc    int,     
  vdate1  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table rela1 (  
  allid   int NOT NULL AUTO_INCREMENT,
  userid1 int,
  userid2 int,    
  vdate1  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table pay01 (  
  allid   int NOT NULL AUTO_INCREMENT,  
  userid  int,         
  payc1   int,    
  payc2   int,    
  ukey    varchar(30),
  vjson   varchar(1024) default '',
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 
  
create table pay02 (  
  allid   int NOT NULL AUTO_INCREMENT,  
  saleno  int,               
  vjson   varchar(4096),
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table pay03 (  
  allid   int NOT NULL AUTO_INCREMENT,  
  userid  int,
  saleno  int,
  payc1   int,
  payc2   int,                 
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table crt_v (  
  allid   int NOT NULL AUTO_INCREMENT,  
  userid  int,  
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table crt_va (  
  allid   int NOT NULL AUTO_INCREMENT,  
  userid  int,
  u_addr  varchar(200),                   
  u_tel   varchar(20),   
  u_bank  varchar(100),
  u_bank1 varchar(40),
  vdate1  datetime default now(),
  vdate2  datetime default now(),
  id01    varchar(01) Default '0',
  id02    varchar(01) Default '0',      
primary key(allid)); 

create table vpay01 (  
  allid   int NOT NULL AUTO_INCREMENT,  
  userid  int,          
  ukey    varchar(30),
  vjson   varchar(1024) default '',
  vdate1  datetime default now(),
  vdate2  datetime default now(),     
primary key(allid)); 
  
create table vpay02 (  
  allid   int NOT NULL AUTO_INCREMENT,  
  userid  int,               
  vjson   varchar(4096),
  vdate1  datetime default now(),
  vdate2  datetime default now(),    
primary key(allid)); 
--網站第一層資料
CREATE TABLE P01M (  
   ALLID    INT IDENTITY(1,1),
   URLPATH  NVARCHAR(200),    
PRIMARY KEY(ALLID));   

CREATE TABLE P01V (
   ALLID    INT IDENTITY(1,1),
   CRTDT    NVARCHAR(30) Default convert(NVARCHAR, getdate(), 120), 
   URLPATH  NVARCHAR(200), 
   PRODNAME NVARCHAR(100) Default '', 
   ID01     NVARCHAR(001) Default '1', 
   TAG1     NVARCHAR(050) Default '',   
   TAG2     NVARCHAR(050) Default '',
   TAG3     NVARCHAR(050) Default '',
PRIMARY KEY(ALLID));  

CREATE TABLE P02V (
   ALLID     INT IDENTITY(1,1),
   CRTDT     NVARCHAR(30) Default convert(NVARCHAR, getdate(), 120), 
   URLPATH   NVARCHAR(200), --路徑
   URLPATH1  NVARCHAR(200), --路徑1,直接到商品路徑
   PRODNAME  NVARCHAR(100), --產品名稱
   AIRLINE   NVARCHAR(050),  --航空公司
   STDATE    NVARCHAR(050),  --出發日期
   WEEKOF    NVARCHAR(050),  --星期
   T_DAY     NVARCHAR(050),  --天數
   SALES     NVARCHAR(050),  --團費
   VISAC     NVARCHAR(050),  --簽證費
   TAXC      NVARCHAR(050),  --稅金
   TIPC      NVARCHAR(050),  --小費
   QTY       NVARCHAR(050),  --機位
   SIGNSTS   NVARCHAR(050),  --報名
   REM       NVARCHAR(050),  --備註
   SALENO    NVARCHAR(100),  --團號
   ISALES    INT Default 0,
   IQTY      INT Default 0,  
   IDAY      INT Default 0,  
   ID01      NVARCHAR(010) Default '1', 
   TAG1      NVARCHAR(050) Default '',   
   TAG2      NVARCHAR(050) Default '',
   TAG3      NVARCHAR(050) Default '',
PRIMARY KEY(ALLID));  

CREATE TABLE Y01V (
   ALLID    INT IDENTITY(1,1),
   URLPATH  NVARCHAR(200), 
PRIMARY KEY(ALLID));  

CREATE TABLE Y02V (
   ALLID     INT IDENTITY(1,1),
   CRTDT     NVARCHAR(30) Default convert(NVARCHAR, getdate(), 120), 
   URLPATH   NVARCHAR(200), --路徑
   URLPATH1  NVARCHAR(200), --路徑1,直接到商品路徑
   PRODNAME  NVARCHAR(100), --產品名稱
   AIRLINE   NVARCHAR(050),  --航空公司
   STDATE    NVARCHAR(050),  --出發日期
   WEEKOF    NVARCHAR(050),  --星期
   T_DAY     NVARCHAR(050),  --天數
   SALES     NVARCHAR(050),  --團費
   VISAC     NVARCHAR(050),  --簽證費
   TAXC      NVARCHAR(050),  --稅金 永信改為候補
   TAXC      NVARCHAR(050),  --稅金 永信改為可售
   TIPC      NVARCHAR(050),  --小費 
   QTY       NVARCHAR(050),  --機位
   SIGNSTS   NVARCHAR(050),  --報名
   REM       NVARCHAR(050),  --備註 永信改為早鳥等優惠
   SALENO    NVARCHAR(100),  --團號
   ISALES    INT,
   IQTY      INT,   
PRIMARY KEY(ALLID));  


INSERT INTO P02V (   
   CRTDT, 
   URLPATH,
   URLPATH1,
   PRODNAME,
   AIRLINE,
   STDATE,
   WEEKOF,
   T_DAY,
   SALES,
   VISAC,
   TAXC,
   TIPC,
   QTY,
   SIGNSTS,
   REM,
   SALENO,
   ISALES,
   ID01,
   IQTY,TAG1,TAG2)   
SELECT 
      CRTDT, 
   URLPATH,
   URLPATH1,
   PRODNAME,
   AIRLINE,
   STDATE,
   WEEKOF,
   T_DAY,
   SALES,
   VISAC,
   TAXC,
   TIPC,
   QTY,
   SIGNSTS,
   REM,
   SALENO,
   ISALES,
   ID01,
   IQTY,TAG1,TAG2
FROM P02V1   

土耳其航空	TK
中華航空	CI
卡達航空	QR
長榮航空	BR
阿聯酋航空	EK
泰國航空	TG
國泰航空	CX
新加坡航空	SQ

候補
已成團
報名
即將成團
結團
保證出團

候補
報名
截止
滿團

已成團
可報名
滿團可候補
即將成團
滿團
滿候補

 <el-table :data="srrec" style="width: 100%" id="excelo">
      <el-table-column prop="ID01" label="公司" width="60" />
      <el-table-column prop="PRODNAME" label="名稱" width="280" />
      <el-table-column prop="AIRLINE" label="班機" width="60" />
      <el-table-column prop="STDATE" label="出發日" width="100" />
      <el-table-column prop="WEEKOF" label="星期" width="60" />
      <el-table-column prop="T_DAY" label="天數" width="60" />
      <el-table-column prop="SALES" label="團費" width="80" />
      <el-table-column prop="VISAC" label="簽證費" width="80" />
      <el-table-column prop="TAXC" label="稅金" width="60" />
      <el-table-column prop="TIPC" label="小費" width="60" />
      <el-table-column prop="QTY" label="機位" width="60" />
      <el-table-column prop="SIGNSTS" label="報名" width="60" />
      <el-table-column prop="REM" label="備註" width="60" />
      <el-table-column prop="SALENO" label="團號" width="160" />
      <el-table-column prop="CRTDT" label="搜尋日期" width="100" />
    </el-table>
	
	MD
馬達加斯加
馬達加斯加航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
AV
哥倫比亞
哥倫比亞航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TA
中美洲
中美洲航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
AK
AirAsia
AirAsia
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
BI
汶航
汶航
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
GA
印尼
印尼航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
MI
勝安
勝安航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
PG
曼谷
曼谷航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
QV
寮國
寮國航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
RA
尼泊爾
尼泊爾航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
8M
緬航
緬甸國際航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TZ
酷航
酷航航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TN
大溪地
大溪地航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
HX
香港
香港航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
UO
香港快運
香港快運航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
MF
廈門
廈門航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
SC
山東
山東航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
ZH
深圳
深圳航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
3U
3U
3U
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
HO
吉祥
吉祥航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
OM
蒙古
蒙古航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
BG
孟航
孟加拉航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
EK
阿酋
阿酋航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
EY
阿提哈德
阿提哈德航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
GF
海灣
海灣航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
KK
土耳其亞特加斯
土耳其亞特加斯航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
KQ
肯亞
肯亞航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TP
葡萄牙航空
葡萄牙航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
MA
匈牙利
匈牙利航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
OK
捷克
捷克航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
OS
奧地利
奧地利航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
SK
北歐航空
北歐航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
SN
比利時航空
比利時航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
SU
俄羅斯航空
俄羅斯航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TK
土耳其航空
土耳其航空
TW-臺灣
TPE-台北市
OK-正常
010-顏海如
001-張榮源
有效
2020/04/18 20:29
系統管理員
2020/04/20 14:08
系統管理員
		
OG
FLYPLAY
冰島FLY航空
IS-冰島
KEF
OK-正常
有效
2023/05/09 11:16
011-陳韋如
2023/05/09 11:16
011-陳韋如
		
JX
星宇航空
星宇航空
JP-日本
KIX-關西
OK-正常
有效
2023/02/21 18:20
103-李富仁
2023/02/21 18:20
103-李富仁
		
FI
冰島航空
冰島航空
IS-冰島
REK
OK-正常
有效
2020/09/29 13:05
2020/09/29 13:05
		
LO
波蘭
波蘭航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
BX
釜山航空
釜山航空

SM
馬尼拉航空
馬尼拉航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
LA
南美
南美航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
Z2
飛龍
飛龍航空
PH-菲律賓
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
K9
通里薩
通里薩航空
KH-柬埔寨
PNH-金邊
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
CM
巴航
巴拿馬航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
FE
遠東
遠東航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
LJ
真航空
真航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
AS
阿拉斯加
阿拉斯加航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
HA
夏威夷
夏威夷航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
US
全美
全美航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
AC
加航
加拿大航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
WS
西捷
西捷航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
AM
墨航
墨西哥國際航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
MX
墨西哥
墨西哥航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
AV
哥倫比亞
哥倫比亞航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TA
中美洲
中美洲航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
AK
AirAsia
AirAsia
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
BI
汶航
汶航
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
GA
印尼
印尼航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
MI
勝安
勝安航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
PG
曼谷
曼谷航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
QV
寮國
寮國航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
RA
尼泊爾
尼泊爾航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
8M
緬航
緬甸國際航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TZ
酷航
酷航航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
TN
大溪地
大溪地航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
HX
香港
香港航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
UO
香港快運
香港快運航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
MF
廈門
廈門航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
SC
山東
山東航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
ZH
深圳
深圳航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
3U
3U
3U
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
HO
吉祥
吉祥航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
OM
蒙古
蒙古航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
BG
孟航
孟加拉航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
EK
阿酋
阿酋航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
EY
阿提哈德
阿提哈德航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
GF
海灣
海灣航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
KK
土耳其亞特加斯
土耳其亞特加斯航空
TW-臺灣
TPE-台北市
OK-正常
有效
2020/04/14 14:43
系統管理員
2020/04/14 14:46
系統管理員
		
KQ
肯亞
肯亞航空







KL 荷蘭皇家航空 
LH 漢莎航空
SQ 新加坡航空
SU 俄羅斯航空

TG 泰國國際航空

QR 卡達航空

OM 蒙古民用航空 
CA 中國國際航空
HO 吉祥航空
MU 中國東方航空 


