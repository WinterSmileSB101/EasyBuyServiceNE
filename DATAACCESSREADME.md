Newegg Oversea Data Access
====================================
_Oversea DataAccess_是Newegg后端系统用于访问Microsoft's SQL Server最主要的组件，它提供一系列的接口用于简单、友好、快速的数据交互，它的灵活性和稳定性经历大量项目验证。

Target Framework Version
----
_DataAccess_基于.NET Framework 4.0编译，可在.NET 4.0或更高版本的32位或64位环境中使用。它本身不依赖任何第三方类库，非常干净。

Getting Started
----
_DataAccess_的最新版本发布在内部Nuget上，快去Nuget添加Package吧。

Configuration
----
_DataAccess_所依赖的全部信息都是配置文件，我们首先需要了解配置文件的结构，默认的结构是这样：  

```
|-web.config  
|-Configuration  
    |-Database.config  
    |-DbCommandFiles.config  
    |-DbCommand1.config  
    |-DbCommand2.config  
    |-DbCommandn.config  
```
- web.config(app.config)  
这些文件的路径在程序集的配置文件中指定，默认的配置如下：   

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="dataAccess" type="Newegg.Oversea.DataAccess.Config.DataAccessSection, Newegg.Oversea.DataAccess" />
  </configSections>
  <dataAccess sqlConfigListFile="Configuration\DbCommandFiles.config" databaseListFile="Configuration\Database.config" />
</configuration>
```

- Database.config  
在一个Database.config文件中，可以添加一个或多个database节点，不同database的名字必须唯一，在定义dataCommand时需要使用这个名字。要特别注意的是，connectionString是使用[Framework Tool](http://trgit/backend_framework/data-access/tree/master/tools/cryption)加密后的文本。   
BTW: `type`所对应的类型包含 `sqlserver`、`odbc`、`oledb`、`mysql`, 默认是 `sqlserver`

```xml
<?xml version="1.0"?>
<databaseList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://oversea.newegg.com/DatabaseList">
	<database name="***database name***">
        <connectionString>***encrypted connection string***</connectionString>
	</database>
	<database name="***database name of mysql***" type="mysql">
        <connectionString>***encrypted connection string***</connectionString>
	</database>
</databaseList>
```
- DbCommandFiles.config  
在这里列举你创建的所有DbCommand.config文件, _DataAccess_加载时会遍历所有文件并缓存在内存中。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<!--
Note:	files specified here can include relative path only. 
      it is recommended not to include any folder info.
      file path is relative to the folder of this configuration file.
-->
<dataCommandFiles xmlns="http://oversea.newegg.com/DbCommandFiles">
    <file name="DbCommand1.config" />
    <file name="DbCommand2.config" />
    <file name="DbCommandn.config" />
</dataCommandFiles>
```

- DbCommand.config  
在一个DbCommand.config文件中，可以包括多个dataCommand节点，其结构的组织可依据业务决定。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<dataOperations xmlns="http://oversea.newegg.com/DataOperation"
				xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <dataCommand name="MyDataCommand" database="***database name***" commandType="Text">
    <commandText>
      <![CDATA[
      SELECT 'Hello, DataAccess'
      ]]>
    </commandText>
  </dataCommand>
</dataOperations>
```

- Exception Level

在程序中不可避免的要产生异常信息，异常信息可以设置三种级别：

    Full: 抛出全部异常信息，包含明文连接字符串。
    Normal: 抛出包含连接字符串的异常信息，但里面用户名和密码会被抹掉。
    Safety: 抛出不含连接字符串的异常信息，建议在生产环境使用。

```xml
<dataAccess sqlConfigListFile="Configuration\DbCommandFiles.config" databaseListFile="Configuration\Database.config" exceptionLevel="Safety" />
```

此项特性仅在1.0.4或更高版本支持，在此之前，异常级别等同于Full。

- Auto detect config files

在一些复杂的项目中，会出现同一个Host引用多个Library的情况，这些Library有自己的配置文件，并且同一Library可能是被多个Host所引用。如果这些来自不同Library的配置文件堆积在一起，势必增加维护的困难。

为了能将不同Library的配置文件具有一定隔离性，可以将它们放在不同的子目录中，看起来像这样：

```
|-web.config  
|-Configuration  
    |-Library1
      |-Database.config  
      |-DbCommandFiles.config  
      |-DbCommand1.config  
      |-DbCommand2.config  
      |-DbCommandn.config  
    |-Library2
      |-Database.config  
      |-DbCommandFiles.config  
      |-DbCommand1.config  
      |-DbCommand2.config  
      |-DbCommandn.config 
```

同时，修改web.config(app.config)中的配置，指定配置文件所在的目录，示例如下：   

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="dataAccess" type="Newegg.Oversea.DataAccess.Config.DataAccessSection, Newegg.Oversea.DataAccess" />
  </configSections>
  <dataAccess configDirectory="Configuration\" />
</configuration>
```

要注意的是，虽然可以将文件分布在不同的子目录，但是Key仍然是不能重复的。

此项特性仅在1.0.4或更高版本支持。

Hello, DataAccess
----
如下代码展示了如何执行DataCommand获取数据：

```c#
DataCommand dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
var result = dataCommand.ExecuteScalar<string>();
//result is 'Hello, DataAccess'
```

Parameterized queries
----
Parameters are passed in as anonymous classes. This allow you to name your parameters easily and gives you the ability to simply cut-and-paste SQL snippets and run them in Query analyzer.

```js
new {A = 1, B = "b"} // A will be mapped to the param @A, B to the param @B 
```

Execute a Command multiple times
----
The same signature also allows you to conveniently and efficiently execute a command multiple times (for example to bulk-load data)

Example usage:

```xml
<dataCommand name="MyDataCommand" database="***database name***" commandType="Text">
<commandText>
  <![CDATA[
  INSERT INTO MyTable(colA, colB) VALUES (@a, @b)
  ]]>
</commandText>
</dataCommand>
```

```c#
DataCommand dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
// 3 rows inserted: "1,1", "2,2" and "3,3"
dataCommand.ExecuteNonQuery(new[] { new { a=1, b=1 }, new { a=2, b=2 }, new { a=3, b=3 } })
```

This works for any parameter that implements IEnumerable<T> for some T.

List Support
----
_DataAccess_ allow you to pass in IEnumerable<int> and will automatically parameterize your query.
For example:

```xml
<dataCommand name="MyDataCommand" database="***database name***" commandType="Text">
<commandText>
  <![CDATA[
  select * from (select 1 as Id union all select 2 union all select 3) as X where Id in @Ids
  ]]>
</commandText>
</dataCommand>
```

```c#
DataCommand dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
dataCommand.ExecuteEntityList<int>(new { Ids = new int[] { 1, 2, 3 });
```

Will be translated to:

```sql
select * from (select 1 as Id union all select 2 union all select 3) as X where Id in (@Ids1, @Ids2, @Ids3) // @Ids1 = 1 , @Ids2 = 2 , @Ids2 = 3
```

For char:

```c#
DataCommand dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
var ids = new DbString[]
{
    new DbString(){IsAnsi = true,IsFixedLength = true,Length = 5,Value= "ALFKI"},
    new DbString(){IsAnsi = true,IsFixedLength = true,Length = 5,Value= "ANATR"},
};
dataCommand.ExecuteEntityList<int>(new { Ids = ids);
```

Buffered vs Unbuffered readers
----
_DataAccess_'s default behavior is to execute your sql and buffer the entire reader on return. This is ideal in most cases as it minimizes shared locks in the db and cuts down on db network time.

However when executing huge queries you may need to minimize memory footprint and only load objects as needed. To do so pass, buffered: false into the Query method.

Multi Mapping
----
_DataAccess_ allows you to map a single row to multiple objects. This is a key feature if you want to avoid extraneous querying and eager load associations.

Example:

```xml
<dataCommand name="MyDataCommand" database="***database name***" commandType="Text">
<commandText>
  <![CDATA[
	select *
	from dbo.Orders O with(nolock)
	inner join dbo.[Order Details] D with(nolock)
	on O.OrderID = D.OrderID
	inner join dbo.Customers C with(nolock)
	on O.CustomerID = C.CustomerID
	where OrderDate >= @From and OrderDate < @To
  ]]>
</commandText>
</dataCommand>
```

```c#
var dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
return dataCommand.ExecuteEntityList<OrderEntity, OrderDetailEntity, CustomerEntity, OrderEntity>(
    (order, detail, customer) =>
    {
        order.OrderDetail = detail;
        order.Customer = customer;
        return order;
    },
    new {From = fromDate, To = toDate},
    "OrderID,CustomerID"
    );
```

**important note** _DataAccess_ assumes your Id columns are named "Id" or "id", if your primary key is different or you would like to split the wide row at point other than "Id", use the optional 'splitOn' parameter.

Multiple Results
----
_DataAccess_ allows you to process multiple result grids in a single query.
Example:

```xml
<dataCommand name="MyDataCommand" database="***database name***" commandType="Text">
<commandText>
  <![CDATA[
	select * from Customers where CustomerId = @id
	select * from Orders where CustomerId = @id
	select * from Returns where CustomerId = @id
  ]]>
</commandText>
</dataCommand>
```

```c#
var dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
using (var multi = dataCommand.ExecuteMultiple(new {id=selectedId}))
{
   var customer = multi.Read<Customer>().Single();
   var orders = multi.Read<Order>().ToList();
   var returns = multi.Read<Return>().ToList();
} 
```

Stored Procedures and Output Parameter
----

```sql
CREATE PROCEDURE [dbo].[GetOrderAmount] 
(
	@OrderID int,
	@Amount decimal(12,4) output
)
AS

SELECT @Amount = OrderAmount
FROM dbo.[Orders] with(nolock)
WHERE OrderID = @OrderID
```

```xml
<dataCommand name="MyDataCommand" database="***database name***" commandType="StoredProcedure">
<commandText>
  <![CDATA[
  dbo.[GetOrderAmount]
  ]]>
</commandText>
</dataCommand>
```

```c#
var dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");

var p = new DynamicParameters();
p.Add("@OrderID", orderID);
p.Add("@Amount", dbType: DbType.Decimal, direction: ParameterDirection.Output, size: 14, precision: 12, scale: 4);
dataCommand.ExecuteNonQuery(p);

var amount = p.Get<decimal>("@Amount");
```

Ansi Strings and varchar
----
_DataAccess_默认使用Nvarchar来映射.NET中的String类型，如果表中存在Char类型字段，并且该字段上有索引，类型不匹配不能使用索引优化，在条件中包括这样的字段将严重影响查询效率。在这种情况下，需要明确指定字段类型。

If you are executing a where clause on a varchar column using a param be sure to pass it in this way:

```xml
<dataCommand name="MyDataCommand" database="***database name***" commandType="Text">
<commandText>
  <![CDATA[
  select * from Thing where Name = @Name
  ]]>
</commandText>
</dataCommand>
```

```c#
DataCommand dataCommand = DataCommandManager.GetDataCommand("MyDataCommand");
var p = new {Name = new DbString { Value = "abcde", IsFixedLength = true, Length = 10, IsAnsi = true };
dataCommand.ExecuteEntityList<Thing>(p);
```

Dynamic Condition
----
在实际业务开发中，经常会有动态条件的查询需求，_DataAccess_为这种场景提供了相应接口：

```xml
<dataCommand name="MyDataCommand" database="***database name***" commandType="Text">
<commandText>
  <![CDATA[
  SELECT * from dbo.Orders
  #StrWhere#
  ORDER BY #SortColumnName#
  ]]>
</commandText>
</dataCommand>
```
注意占位词(#StrWhere#,#SortColumnName#)不能改变，否则生成后SQL后会替换失败。

```c#
CustomDataCommand dataCommand = DataCommandManager.CreateCustomDataCommandFromConfig("MyDataCommand");

using (DynamicQuerySqlBuilder sqlBuilder = new DynamicQuerySqlBuilder(
   dataCommand.CommandText, dataCommand, new PagingInfoEntity(), "CustomerID ASC,OrderDate DESC"))
{
	if (id != null)
    {
        sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "OrderID", DbType.Int32, "@OrderID", QueryConditionOperatorType.Equal, id.Value);
    }
	if(OrderDate != null)
	{
	    sqlBuilder.ConditionConstructor.AddCustomCondition(QueryConditionRelationType.AND,
	        "OrderDate>@OrderDate");
	    dataCommand.AddInputParameter("OrderDate", System.Data.DbType.DateTime);
	    dataCommand.SetParameterValue("OrderDate", OrderDate.Value);
    }

    //查询数据
    dataCommand.CommandText = sqlBuilder.BuildQuerySql();
    var result = dataCommand.ExecuteEntityList<OrderEntity>();
}
```

Mock Function
----
在一个项目中，如果使用了DataAccess底层框架，由于牵扯到数据库这样的外部依赖在进行单元测试的时候就不是很方便。

为此，我们在_DataAccess_中提供了**Mock**功能，详细请[阅读](http://trgit2/backend_framework/data-access/wikis/mock-for-unit-test)

Bulk Copy
----
BulkCopy主要用于在项目中进行批量插入数据（数据量太大的情况），需要注意的是你传入的对象所包含的字段需要与数据库中实际表的字段一致（不能多、可以少）。
```C#
var list = new List<BatchTestInfo>();
var cmd = DataCommandManager.CreateCustomDataCommand("Local");
cmd.ExecuteBulkCopy("BatchTest", list);
```
Trace
----
可以获取打印SQL与已设置的参数信息，这样方便在一些测试环境直接Trace程序产生的数据查询语句，方便定位问题。需要在配置文件中设置IfTrace为True和logPath（Log保存目录）。
````xml
<dataAccess sqlConfigListFile="Configuration\DbCommandFiles.config" databaseListFile="Configuration\Database.config" exceptionLevel="Full"
    useMock="true" IfTrace ="true" logPath ="Log\" />
````

Performance
----
A key feature of _DataAccess_ is performance. The following metrics show how long it takes to execute 500 SELECT statements against a DB and map the data returned to objects.

Method  | Duration
------------- | -------------
Hand coded (using a SqlDataReader):    |47ms
**DataAccess** ExecuteMapperQuery<Post>: |49ms
ServiceStack.OrmLite (QueryById):      |50ms
NHibernate SQL:                        |104ms
Linq 2 SQL ExecuteQuery:               |181ms
Entity framework ExecuteStoreQuery:    |631ms

License
----
Copyright (c) 2014 Newegg inc. All Rights Reserved.

About us
----
我们是BTS（Backend Tech Support） team。  
欢迎访问我们的[Blog](http://10.16.75.10:8002/)与我们进行交流。

![BTS](http://neg-app-img/MISInternal/DocumentTool/20140304042540930_easyicon_net_128.1394693687.ico)
