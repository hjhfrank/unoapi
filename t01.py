import requests
#url = 'http://localhost:60334/API/testapi1'
url = 'http://localhost:60334/API/testapi'
myobj = {'somekey': 'somevalue'}
#x = requests.post(url, json = myobj)
x = requests.get(url,data=myobj)
print(x.json())