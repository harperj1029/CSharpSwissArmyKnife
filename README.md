# CSharpUtilities
Handy C# extensions and utilities.


## _ExpandoObject_ Extensions

### Usage
Combine properties from several objects. Simple and effective when type information is not needed by the consumer. For example, sending arguments to [Dapper](https://github.com/StackExchange/Dapper).
```
var foo = new { Foo = "Foo" };
var bar = new { Bar = "Bar" };
var baz = new { Baz = "Baz" };

dynamic result = new ExpandoObject().AddProperties(foo).AddProperties(bar).AddProperties(baz);
```
