#pip install fastapi # FastAPI
#pip install uvicorn[standard] # ASGI Server
#pip install psycopg2-binary
#uvicorn main:app --reload --host 192.168.1.29
from typing import Optional
from fastapi import FastAPI, Request
from fastapi.encoders import jsonable_encoder
import psycopg2
from psycopg2.extras import RealDictCursor
from datetime import datetime
from fastapi.middleware.cors import CORSMiddleware
import uvicorn

def get_db_connection():
    conn = psycopg2.connect(host='192.168.1.31',
                            database='testdb',
                            user='postgres',
                            password='hjhjack')
    #server = 'localhost' 
    #database = 'testdb' 
    #username = 'postgres' 
    ##password = 'hjhjack'     
    ##conn = pyodbc.connect('DRIVER={PostgreSQL Unicode};SERVER='+server+';port=5432;DATABASE='+database+';UID='+username+';PWD='+ password)
    return conn

def RunSQL(sSQL):
    conn = get_db_connection()           
    cur = conn.cursor()    
    cur.execute(sSQL) 
    listv = cur.fetchall()        
    cur.close()
    conn.commit()
    conn.close()     
    return listv

def chk_login(v1,v2):
    conn = get_db_connection()           
    cur = conn.cursor()    
    cur.execute("SELECT userid from webuser where userid='"+v1+"' and userpass='"+v2+"'")  
    listv = cur.fetchall()        
    cur.close()
    conn.commit()
    conn.close()       
    if len(listv)==0:
        return False
    else:    
        return True

def chkUOneKey(v1,v2):
    vsql="select allid from usertoken where vdate='"+v1+"' and skey='"+v2+"'"
    conn = get_db_connection()       
    cur = conn.cursor()    
    cur.execute(vsql)  
    listv = cur.fetchall()        
    cur.close()
    conn.commit()
    conn.close()         
    if len(listv)>0:
        return False
    else:    
        return True

def InsertUKey(v1):
   s2=datetime.now()
   s1=s2.strftime('%Y%m%d') 
   asql=[]
   vsql='select to_hex(random_between(10,255)) a01,'
   vsql=vsql+'to_hex(random_between(10,255)) a02,'
   vsql=vsql+'to_hex(random_between(10,255)) a03,'
   vsql=vsql+'to_hex(random_between(10,255)) a04,'
   vsql=vsql+'to_hex(random_between(10,255)) a05,'
   vsql=vsql+'to_hex(random_between(10,255)) a06,'
   vsql=vsql+'to_hex(random_between(10,255)) a07,'
   vsql=vsql+'to_hex(random_between(10,255)) a08,'
   vsql=vsql+'to_hex(random_between(10,255)) a09,'
   vsql=vsql+'to_hex(random_between(10,255)) a10;'   
   nLOOP=0   
   s3=""
   while (nLOOP==0):
       s3=""
       aSQL=[]
       asql=RunSQL(vsql)      
       nI=0
       while (nI<10):
         s3=s3+asql[0][nI]                 
         nI=nI+1        
       if chkUOneKey(s1,s3):
           nLOOP=-1  
   asql=[]
   vsql="delete from usertoken where vdate='"+s1+"' and userid='"+v1+"';"   
   asql.append(vsql)
   vsql="insert into usertoken(vdate,userid,skey) values ({p1},{p2},{p3});".format(p1="'"+s1+"'",p2="'"+v1+"'",p3="'"+s3+"'")
   asql.append(vsql)
   try:                                          
       conn = get_db_connection()    
       cur = conn.cursor()
       for vsql in asql:
           cur.execute(vsql)               
       conn.commit()                           
       conn.close()                  
   except:
       s3='Error'                        
   return s3               

def getUserKey(v1):
    lRET=False
    s2=datetime.now()
    s1=s2.strftime('%Y%m%d') 
    vsql="select allid from usertoken where vdate='"+s1+"' and skey='"+v1+"';"    
    try:                                          
        conn = get_db_connection()    
        cur = conn.cursor()       
        cur.execute(vsql)  
        listv = cur.fetchall()                
        conn.commit()                           
        conn.close()                  
        if len(listv)>0:            
            lRET=True
    except:
        lRET=False       
    return lRET           

app = FastAPI() # 建立一個 Fast API application

#origins = [
#    "http://localhost.tiangolo.com",
#    "https://localhost.tiangolo.com",
#    "http://localhost",
#    "http://localhost:8080",
#     //客戶端的源
#    "http://127.0.0.1:8081"
#]
 
# 3、配置 CORSMiddleware
app.add_middleware(
    CORSMiddleware,
    #allow_origins=origins,  # 允許訪問的源
    allow_origins=["*"],
    allow_credentials=True,  # 支援 cookie
    allow_methods=["*"],  # 允許使用的請求方法
    allow_headers=["*"]  # 允許攜帶的 Headers
)
 
@app.get("/") # 指定 api 路徑 (get方法)
def read_root():
    #slistv=RunSQL('select prod_id,prod_name from prod')
    #return jsonable_encoder(RunSQL('select prod_id,prod_name from prod'))
    return {"Hello": "Worldaaa"}

@app.post("/login") # 指定 api 路徑 (post方法)
def login(data:dict):    
    #print(data)
    v1=data['userid']
    v2=data['userpassword']                   
    if chk_login(v1,v2):       
        v3=InsertUKey(v1)
        if v3=='Error':                    
            response = {'msg':'ng','vkey':'ng'}
        else:
            response = {'msg':'ok','vkey':v3,'userid':v1} 
    else:               
        response = {'msg':'ng','vkey':'ng'}
    return response                         

if __name__=="__main__":
    uvicorn.run("main:app",reload=True)