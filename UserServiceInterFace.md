# EasyBuyService InterFace

## api/user METHOD==> PUT
## RequestBody
```json
{
  "UserID":"9SIA24G6BZ5991",
  "UserName":"az8g",
  "UserPassWord":"9627191063",
  "Email":"Alvin.X.Zhang@newegg.com",
  "Phone":"12345678910",
  "Role":"00000",
  "InUser":"az8g"
}
```

## ReponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": true
}
```

## api/user METHOD==> POST
## RequestBody
```json
{
  "UserID":"9SIA24G6BZ5991",
  "UserName":"az8g",
  "InUser":"az8g"
}
```

## ReponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": true
}
```

## api/user METHOD==> POST
## RequestBody
```json
{
  "UserID":"9SIA24G6BZ5991",
  "UserPassWord":"9627191063",
  "InUser":"az8g"
}
```

## ReponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": true
}
```

## api/user METHOD==> POST
## RequestBody
```json
{
  "UserID":"9SIA24G6BZ5991",
  "Email":"Alvin.X.Zhang@newegg.com",
  "InUser":"az8g"
}
```
## ReponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": true
}
```

## api/user METHOD==> POST
## RequestBody
```json
{
  "UserID":"9SIA24G6BZ5991",
  "Phone":"12345678910",
  "InUser":"az8g"
}
```
## ReponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": true
}
```

## api/user METHOD==> POST
## RequestBody
```json
{
  "UserID":"9SIA24G6BZ5991",
  "Role":"00000",
  "InUser":"az8g"
}
```

## ReponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": true
}
```

## api/user METHOD==> GET
## ResponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": [
  {
"UserID": "1",
"UserName": "az8g",
"UserPassWord": "111111",
"Email": "Alvin.X.Zhang@newegg.com",
"Phone": "12345678910",
"LastChangeUserNameDate": "/Date(1512921600000+0800)/",
"Role": "11111",
"InDate": "/Date(1512921600000+0800)/",
"InUser": "az8g",
"LastEditDate": "/Date(1512921600000+0800)/",
"LastEditUser": "az8g"
},
  {
"UserID": "1213546",
"UserName": "az8g",
"UserPassWord": "111111",
"Email": "Alvin.X.Zhang@newegg.com",
"Phone": "12345678910",
"LastChangeUserNameDate": "/Date(1512921600000+0800)/",
"Role": "11111",
"InDate": "/Date(1512921600000+0800)/",
"InUser": "az8g",
"LastEditDate": "/Date(1512921600000+0800)/",
"LastEditUser": "az8g"
},
  {
"UserID": "9SIA24G6BZ5991",
"UserName": "az8g",
"UserPassWord": "9627191063",
"Email": "Alvin.X.Zhang@newegg.com",
"Phone": "12345678910",
"LastChangeUserNameDate": "/Date(1506417952310+0800)/",
"Role": "00000",
"InDate": "/Date(1514280352310+0800)/",
"InUser": "az8g",
"LastEditDate": "/Date(1514280352310+0800)/",
"LastEditUser": "az8g"
},
  {
"UserID": "9SIA24G6BZ5991",
"UserName": "az9g",
"UserPassWord": "9627191064",
"Email": "Alvin.X.Zhang@newegg.comasdad",
"Phone": "12345678911",
"LastChangeUserNameDate": "/Date(1514274732810+0800)/",
"Role": "11111",
"InDate": "/Date(1514274575880+0800)/",
"InUser": "az8g",
"LastEditDate": "/Date(1514274924193+0800)/",
"LastEditUser": "az8g"
}
],
"TotalCount": 4
}
```