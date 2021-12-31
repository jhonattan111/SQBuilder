# SQBuilder
Project that creates a SQL script builded dinamically

Class that create a SQL Script dinamically

Use examples
```C#
var query = new SQLBuilder
                .Select("O.Id, O.Code")
                .From("dbo.Order O")
                .Where("O.Id = 1");
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT O.Id, O.Code FROM dbo.Order O WHERE O.Id = 1 --query
```
In case like that, this looks like terrible, implement a class to write a simple script. The power comes with classes like where that you can define with a bool if add that clause

```C#

bool print = true;
var query1 = new SQLBuilder
                .Select("O.Id, O.Code")
                .From("dbo.Order O")
                .Where("O.Id = 1", print);
                
                
var query2 = new SQBuilder
                .Select("O.Id, O.Code")
                .From("dbo.Order O")
                .Where("O.Id = 1", !print);
                
Console.WriteLine(query1.ToString());
Console.WriteLine(query2.ToString());
```
```SQL
SELECT O.Id, O.Code FROM dbo.Order O WHERE O.Id = 1 --query1
SELECT O.Id, O.Code FROM dbo.Order O --query2
```
If you have a class that represents your sql columns you can simply add a Select<T> and generate a script with all your atributes, with a parameter that represents your column, or without a argument
  
```C#
var query = new SQLBuilder()
              .Select<Company>("P")
              .From("dbo.Table1 P")
              .Where("");
                
                
var query2 = new SQLBuilder()
              .Select<Company>()
              .From("dbo.Table1 P")
              .Where("");
                
Console.WriteLine(query1.ToString());
Console.WriteLine(query2.ToString());
```
```SQL
SELECT P.Id, P.Name, P.Adress FROM dbo.Table1 P --query1
SELECT Id, Name, Adress FROM dbo.Table1 P --query2
```

You can write a WHERE clause using IN, you can do this with a string or int list
```C#
var strList = new List<string>() {"Mouse", "Keyboard", "HDMI"}

var query = new SQLBuilder
                .Select("P.Id, P.Description")
                .From("dbo.Product P")
                .Where(strList, "P.Description");
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.Id, P.Description FROM dbo.Product P WHERE P.Description IN ('Mouse', 'Keyboard', 'HDMI') --query
```

```C#
var intList = new List<int>() {1, 2, 3, 4, 5}

var query = new SQLBuilder
                .Select("P.Id, P.Description")
                .From("dbo.Product P")
                .Where(intList, "P.Id");
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.Id, P.Description FROM dbo.Product P WHERE P.Id IN ('1', '2', '3', '4', '5') --query
```

And you can do it conditionally

```C#
var condition = false;
var strList = new List<string>() {"Mouse", "Keyboard", "HDMI"}

var query = new SQLBuilder
                .Select("P.Id, P.Description")
                .From("dbo.Product P")
                .Where(strList, "P.Description", condition);
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.Id, P.Description FROM dbo.Product P --query
```

```C#
var condition = false;
var intList = new List<int>() {1, 2, 3, 4, 5}

var query = new SQLBuilder
                .Select("P.Id, P.Description")
                .From("dbo.Product P")
                .Where(intList, "P.Id", condition);
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.Id, P.Description FROM dbo.Product P WHERE P.Id --query
```

You also can add GROUP BY and ORDER BY in your queries

```C#

var query = new SQLBuilder
                .Select("P.Id, P.Description")
                .From("dbo.Product P")
                .OrderBy("P.Id DESC");
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.Id, P.Description FROM dbo.Product P WHERE P.Id ORDER BY Id DESC --query
```

```C#

var query = new SQLBuilder
                .Select("P.GroupId, SUM(P.Revenue) AS [Revenue]")
                .From("dbo.Product P")
                .GroupBy("P.GroupId");
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.GroupId, SUM(P.Revenue) AS [Revenue] FROM dbo.Product P GROUP BY P.GroupId --query
```
