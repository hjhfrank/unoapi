import requests
import io
from selenium import webdriver
from selenium.webdriver.common.by import By
import pyscreenshot as ImageGrab
#import ddddocr     
from PIL import Image
import pytesseract
import time

def findss(s1,s2):
    n1=0
    try:
       n1=s1.index(s2)    
    except:
       n1=-1
    #print(n1)   
    return n1    
#鳳凰旅遊所有產品都放在陣列裡面,順著路徑下去就對了
baseurl="https://www.travel.com.tw/"
urllist=[]
urllist.append("https://www.travel.com.tw/HALL/Index/EU")
urllist.append("https://www.travel.com.tw/HALL/Index/AM")
urllist.append("https://www.travel.com.tw/HALL/Index/RU")
urllist.append("https://www.travel.com.tw/HALL/Index/OO")
urllist.append("https://www.travel.com.tw/HALL/Index/SM")
urllist.append("https://www.travel.com.tw/hall/index/IN")
urllist.append("https://www.travel.com.tw/HALL/Index/FA")
urllist.append("https://www.travel.com.tw/HALL/Index/SS")
urllist.append("https://www.travel.com.tw/HALL/Index/SN")
urllist.append("https://www.travel.com.tw/hall/index/KR")
urllist.append("https://www.travel.com.tw/HALL/Index/CN")
urllist.append("https://www.travel.com.tw/HALL/Index/PT")
url=urllist[0]
list1=[]
x = requests.get(url)
s1=x.text
with open("t03.txt", "w",encoding="utf-8") as file:
    file.write(s1)
file1 = open('t03.txt', 'r',encoding="utf-8")
Lines = file1.readlines()    
file1.close
for line in Lines: 
    #print(line) 
    if findss(line,"<a href=")>0:
        if findss(line,"/TOU/TOU0010/")>0:
            if findss(line,"https://")<0:
                #list1.append(line)    
                s1=line
                s1=s1[findss(s1,"<a href=")+9:]
                s1=s1[0:findss(s1,'"')]                           
                list1.append(s1+'\n')
file1=open("t031.txt", "w",encoding="utf-8")
file1.writelines(list1)    
file1.close        
n1=0
n2=len(list1)-1
#driver = webdriver.Firefox()
headers = headers = {'user-agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_3) AppleWebKit/604.5.6 (KHTML, like Gecko) Version/11.0.3 Safari/604.5.6'}
#driver.get(baseurl+list1[n1])
#driver.switch_to.window(driver.current_window_handle)
#pic = ImageGrab.grab(bbox=(200,310,1160,400))
#pic = pic.convert("L")
#pic.save('1.bmp')
#driver.close()
#ocr = ddddocr.DdddOcr()
#with open('1.bmp', 'rb') as f:
#    img_bytes = f.read()
#res = ocr.classification(img_bytes)
#print(res)
#img_main = Image.open('1.jpg')
#img_main = img_main.convert('L')
#threshold1 = 138
#table1 = []
#for i in range(256):
#    if i < threshold1:
#        table1.append(0)
#    else:
#        table1.append(1)
#img_main = img_main.point(table1, "1")
#img_main.save('2.jpg')

#img = Image.open('1.bmp')
#text1 = pytesseract.image_to_string(img, lang='chi_tra')
#print(text1)
#with open("1.txt", "w",encoding="utf-8") as file:
#    file.write(text1)

while (n1<=n2):
    print(baseurl+list1[n1]) 
    driver = webdriver.Firefox()
    driver.get(baseurl+list1[n1])     
    #driver.switch_to.window(driver.current_window_handle)
    #pic = ImageGrab.grab(bbox=(100,300,1200,800))
    #pic = pic.convert("L")
    #s2=str(n1+1)+'.bmp'
    #pic.save(s2)
    s1 = driver.find_element(By.CLASS_NAME, 'table-hover').text
    #print(s1)
    s2=str(n1+1)+".txt"
    with open(s2, "w",encoding="utf-8") as file:
        file.write(s1) 
    driver.close()
    driver.quit()
    #s2=str(n1+1)+'.bmp'
    #img = Image.open(s2)
    #text1 = pytesseract.image_to_string(img, lang='chi_tra') 
    #s2=str(n1+1)+".txt"
    #with open(s2, "w",encoding="utf-8") as file:
    #    file.write(text1)
    #time.sleep(5)    
    n1=n1+1