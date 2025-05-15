# Notes

## IDEs

- Visual Studio (full-fledged IDE)
- JetBrains Rider (full-fledged IDE)
- VS Code (text editor + extensions) <== free

## Type system

- value types: exist on the stack
- reference types: exist on the heap
  - garbage collected

Value types in .NET:

- `long` 8 BYTES/64-bit -9.223.372.036.854.775.808
- `int` 4 bytes/32-bit 2^32 -2.147.xxx.xxx - 2.147.xxx.xxx
- `short` 2 bytes/16 bit 2^16 -32.768 - 32.767
- `ulong`
- `uint` 0 - 4.294.xxx.xxx
- `ushort` 0 - 65536
- `float` 32 bits
- `double` 64 bits
- `decimal` 128 bits
- `boolean` `true`/`false`
- `char` `'a'` `'e'` `'j'` `'p'` no unicode
- `enum`
- `struct`

## `is null` vs `== null`

C# has a language feature called "operator overloading" that allows for custom behavior with operators. `== null` can be overloaded, `is null` cannot. For this reason, `is null` is regularly preferred over `== null`.


## Pillars of Object Orientation (OO)

- abstraction
- inheritance
- encapsulation
- polymorphism

COBOL AS/400: procedural languages with scripts of 6000+ lines long

web applications on enterprise level
- loads of pages/screens
- lots of CRUD screens
- lots of logic is pretty much the same
  - or looks very alike
- lots of parts can be REUSED - 300+ screens


Class vs instance/object:

```cs
class Bicycle { ... } // class

new Bicycle(); // instance / object
new Bicycle(); // instance / object
new Bicycle(); // instance / object
```

## Access modifiers

- `public`
  - the entire world
- `protected`
  - class itself and derivatives (subclasses) - inheritance
- `internal`
  - only visible for that project
- `private`
  - only the class itself

## Inheritance

- parent classes / child classes
- slightly different behavior for children

where to inherit:

- domain classes/entities
- technical stuff:
  - web APIs    : Controller/ControllerBase
  - filter:   ActionFilter
  - custom validators   : AbstractValidator<>
  - DTOs     : PaginationDto
  - EF Core   :  DbContext
  - Identity   : IdentityUser/IdentityRole  IdentityDbContext
  - custom exceptions (errors)   : Exception

## Interfaces

- class with only abstract methods
- only describe how classes can be talked to
- contract
  - server-server
  - client-server
  - server-external third-party server
- polymorphism
  - dependency injection 90%
- always start with an I
- abstract classes can still have an implementation

examples: `IWhatever`  `ISomeService`  `IBillable`

why interfaces vs parent class / abstract class? differences?
- abstract class has an implementation
- interface does not

interface is very cold separation between all implementations. similar to Ruby mixins?

interfaces are used *a lot* with dependency injection:
- `ProductRepository` with `IProductRepository`

## Bit of history

.NET Framework - 2002
- Windows only

.NET Core - 2016
- Windows, MacOS, Linux
- They tried a `project.json`
- `.csproj` became readable

## Generics

where one can find these generics:

- lists: `List<T>` `LinkedList<>` `Dictionary<>` `IEnumerable<T>` `ICollection<T>` `IList<T>`
- testing:  `new Mock<T>()`
- nullability:  `int?`  `Nullable<int>`
- dependency injection in ASP.NET Core
  ```cs
  builder.Services.AddSingleton<IProductRepository, ProductInMemoryRepository>();
  ```
- delegates `Func<T, bool>` `Predicate<T>` `Action<T>`
- Blazor `EventCallback<T>`
- FluentValidation
  ```cs
  class ProductValidator : AbstractValidator<ProductEntity>
  {

  }
  ```



```cs
public Calculator
{
	public T Add<T>(T x, T y)
	{

	}
}
new Calculator<float>
new Calculator<decimal>
```

## Entity Framework Core

One of the common packages of Microsoft

- Entity Framework: databases
- Identity: authentication/authorization
- System.Text.Json: JSON (de)serialization
- ...

EF Core is part of ADO.NET - ~~ActiveX~~ Data Objects .NET. It aims to not have code like this anymore:

- 2002-2008
  ```cs
  var connection = new SqlConnection();
  connection.Open();
  var command = new SqlCommand(connection);
  command.CommandType = CommandType.Text;
  command.CommandText = "SELECT * FROM customer;"; // SQL injection
  var reader = command.ExecuteReader();

  while (reader.Next())
  {
    reader["name"]
    int.Parse(reader["age"])
    reader["id"]
  }
  ```
- ~2005 Datasets/datatables
- 2008 LINQ to SQL - n:m no support. Only SQL Server.
- 2009 Entity Framework - very much like LINQ to SQL, but with support for n:m and multi-database
- 2016 .NET Core with Entity Framework Core <== currently the default for most projects

NuGet packages - assembly .dll
- Microsoft.EntityFrameworkCore
  - abstractions   DbContext DbSet<>
- database provider for EF Core -  Microsoft.EntityFrameworkCore.SqlServer
  - Sqlite

[Connectionstrings.com](https://www.connectionstrings.com/sqlite/) has handy examples for lots of connectionstrings to all kinds of databases.

### Alternatives

- [Dapper](https://github.com/DapperLib/Dapper) - more lightweight, still have to query using strings, but it's fast, multi-database and more readable than doing everything by hand.
- Hibernate  NHibernate

### Cost of I/O and `async`/`await`

[I/O operations are costly](https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fblog.mixu.net%2Ffiles%2F2011%2F01%2Fio-cost.png&f=1&nofb=1&ipt=0992119d26aba7e6d23fab38ef8ac8708e178b240c780de418dc01ecf82e6d6a) and shouldn't be synchronous operations as if you're creating an integer variable.

```cs
// PHP
mysql_query($query);

// Java
em.persist(obj);

// .NET
command.ExecuteReader();
context.SaveChanges();
```

Better:

```cs
await context.SaveChangesAsync();
await context.Products.SingleAsync(p => p.Id == id);
await context.Products.ToListAsync();
await context.Products.ToArrayAsync();
```

Biggest downside? You'll have to define your method as `async` and all calling methods will have to be made `async` as well. It's often easiest to do this right from the start.
