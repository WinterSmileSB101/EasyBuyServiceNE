# EasyBuyService InterFace

## api/useraddress METHOD==> PUT
## RequestBody
```json
{
  "UserID":"9SIA24G6BZ5991",
  "CustomerName":"az8g",
  "CustomerPhone":"12345678910",
  "CustomerPostCode":"610405",
  "Province":"sc",
  "City":"cd",
  "County":"china",
  "Town":"asd",
  "Village":"sdfffasdad",
  "DetailedAddress":"asdasd,asdasd,asdasd",
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
  "CustomerName":"az8g",
  "CustomerPhone":"12345678911",
  "CustomerPostCode":"610405",
  "Province":"sc",
  "City":"cd",
  "County":"china",
  "Town":"asd",
  "Village":"sdfffasdad",
  "DetailedAddress":"asdasd,asdasd,asdasd",
  "LastEditUser":"az8g"
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
"AddressID": "2",
"UserID": "9SIA24G6BZ5991",
"CustomerName": "az8g",
"CustomerPhone": "12345678910",
"CustomerPostCode": "610405",
"Province": "sc",
"City": "cd",
"County": "china",
"Town": "asd",
"Village": "sdfffasdad",
"DetailedAddress": "asdasd,asdasd,asdasd",
"InDate": "/Date(1514279934500+0800)/",
"InUser": "az8g",
"LastEditDate": "/Date(1514279934500+0800)/",
"LastEditUser": "az8g"
}
],
"TotalCount": 1
}
```

## api/user METHOD==> DELETE
## ResponseBody
```json
{
  "UserID":"9SIA24G6BZ5991"
}
```

## ResponseBody
```json
{
"Code": 200,
"Message": "OK",
"ResultEntity": true
}
```