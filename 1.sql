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
