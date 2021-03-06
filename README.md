# CSharpSwissArmyKnife
Handy C# extensions and utilities. See unit tests for specifics.


## _ExpandoObject_ Extensions

### AddProperties
Combine properties from several objects. Simple and effective when type information is not needed by the consumer. For example, sending arguments to [Dapper](https://github.com/StackExchange/Dapper).
```
var foo = new { Foo = "Foo" };
var bar = new { Bar = "Bar" };
var baz = new { Baz = "Baz" };

// result contains all 3 objects' properties.
dynamic result = new ExpandoObject().AddProperties(foo).AddProperties(bar).AddProperties(baz);
```

## _Object_ Extensions

### DeepClone
Create a clone of an object including nested objects. The clone is a full [deep] cone, not a copy of references.
```
class Foo{
    public Bar Bar{get;set;}
}
class Bar{
    public string Baz{get;set;}
}
var foo = new Foo { Bar = new Bar { Baz = "Foo-Bar-Baz" } };

// fooClone is a deep copy of foo.
var fooClone = foo.DeepClone();
```

### CopyProperties
Copies public properties from the source to the destination where the name and type match.

```
class Foo{
    public string Bar{get;set;}
}

var source = new Foo{Bar = "source"};
var destination = new Foo{Bar = "destination"};

destination.CopyProperties(source);

// source.Bar == "destination"
```

## _Byte array_ Extensions

### FromArray
Get an encoded string from a byte array.

```
var bytes = new byte[] { 0x66, 0x6f, 0x6f };
var myString = bytes.FromArray(); // (default UTF8 encoding)

// myString == "foo"
```

## _String_ Extensions
Get an encoded string from a byte array.

### ToArray

```
var bytes = "foo".ToArray(); // (defaults to UTF8 encoding)

// bytes == new byte[] { 0x66, 0x6f, 0x6f }
```
