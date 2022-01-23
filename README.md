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
With .Top(int num) you can add a TOP clause to your code

```C#
var query = new SQLBuilder
                .Select("O.Id, O.Code")
                .From("dbo.Order O")
                .Top(10)
                .Where("O.Id = 1");
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT TOP 10 O.Id, O.Code FROM dbo.Order O WHERE O.Id = 1 --query
```

SQLBuilder has support for INNER JOIN, LEFT JOIN and RIGHT JOIN

```C#
    var query = new SQLBuilder()
      .Select("T1.*")
      .From("dbo.Table1 T1")
      .LeftJoin("dbo.Table2 T2 ON T1.Id = T2.T1Id")
      .InnerJoin("dbo.Table3 T3 ON T2.Id = T3.T2Id")
      .LeftJoin("dbo.Table4 T4 ON T3.Id = T4.T3Id")
      .RightJoin("dbo.Table5 T5 ON T4.Id = T5.T4Id")
      .Where("T1.Id = 1");
```
```SQL
    SELECT T1.*
    FROM dbo.Table1 T1
    LEFT JOIN dbo.Table2 T2 ON T1.Id = T2.T1Id
    INNER JOIN dbo.Table3 T3 ON T2.Id = T3.T2Id
    LEFT JOIN dbo.Table4 T4 ON T3.Id = T4.T3Id
    RIGHT JOIN dbo.Table5 T5 ON T4.Id = T5.T4Id
    WHERE T1.Id = 1
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
SQLBuilder has support for HAVING clause

```C#

var query = new SQLBuilder()
              .Select("O.Date, SUM(O.Revenue")
              .From("dbo.Order O")
              .GroupBy("O.Date")
              .OrderBy("O.Date DESC")
              .Having("SUM(O.Revenue)");
                
Console.WriteLine(query.ToString());
```
```SQL
  SELECT O.Date, SUM(O.Revenue 
  FROM dbo.Order O 
  GROUP BY O.Date 
  HAVING SUM(O.Revenue) 
  ORDER BY O.Date DESC --query
```

  
In classes that contain properties with names differents of database you can add a annotation to allows the select based on annotation name
  
```C#
internal class Employee
  {
      [ColumnName("i_employee")]
      public int Id { get; set; }
      [ColumnName("name_emp")]
      public string Name { get; set; }
      [IgnoreColumn]
      public string Adress {get; set;}
  }
```
  You can use [ColumnName] to set your column name in db, or if you cant use some propertie you simply use [IgnoreColumn] and it will be ignored
  
```C#
var query = new SQLBuilder
              .Select<Employee>()
              .From("dbo.employee E");
                
Console.WriteLine(query.ToString());
```
```SQL
SELECT i_employee AS Id, name_emp AS Name FROM dbo.employee E --query
```

UNION AND UNION ALL
SQbuilder can generate sql script with UNION and UNION ALL only adding .Union() and UnionAll() between queries.
  
```C#
var query = new SQLBuilder()
              .Select("P.Id, P.Name")
              .From("dbo.Table1 P")
              .Union()
              .Select("T.Id, T.Name")
              .From("dbo.Table2 T");
  
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.Id, P.Name FROM dbo.Table1 P 
UNION 
SELECT T.Id, T.Name FROM dbo.Table2 T --query
```
```C#
var query = new SQLBuilder()
              .Select("P.Id, P.Name")
              .From("dbo.Table1 P")
              .UnionAll()
              .Select("T.Id, T.Name")
              .From("dbo.Table2 T");
  
Console.WriteLine(query.ToString());
```
```SQL
SELECT P.Id, P.Name FROM dbo.Table1 P 
UNION ALL
SELECT T.Id, T.Name FROM dbo.Table2 T --query
```
  
You can add more than one Union and UnionAll clauses, you can even add both
