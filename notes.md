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

NuGet packages you'll need:
- Microsoft.EntityFrameworkCore
  - contains abstractions `DbContext` `DbSet<>`
- the package with the database provider for EF Core
  - SQL Server: Microsoft.EntityFrameworkCore.SqlServer
  - Sqlite: Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools/Design for managing migrations

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

## ASP.NET Core

Usable for many applications:

- Web APIs - REST API  GET POST PUT PATCH DELETE  HTTP-requests
- SignalR - realtime apps - chat multiplayer game  food ordering app
- gRPC - server-to-server communication - highly useful when send loads of data to other servers (>10MB)
- traditional web pages (MPA) - Razor Pages/Blazor
- SPA - Blazor

It boots up a web server: Kestrel



## Web API / REST API

REpresentational State Transfer

client (browser/script) => `/api/products`
- it's representational thanks to the `Accept` header: `Accept: text/html, application/xml, application/json`

focuses on DATA


HTTP verbs:
- GET  api/product  retrieve
- POST  api/product  creating           /updating
- DELETE  deleting
- PUT                replacing          /creating
- PATCH partial update

```sh
POST  api/product  { description: '...', price: 34 }
POST  api/product  { description: '...', price: 34 }
POST  api/product  { description: '...', price: 34 }
POST  api/product  { description: '...', price: 34 }

PUT  api/product/156   { id: 156, description: '...', price: 34 }
PUT  api/product/156   { id: 156, description: '...', price: 34 }
PUT  api/product/156   { id: 156, description: '...', price: 34 }
PUT  api/product/156   { id: 156, description: '...', price: 34 }
```

Difference in results: idempotency

HTTP status codes

- 2xx - SUCCESS  good stuff
  - 200 OK
  - 201 CREATED
  - 204 NO CONTENT   - often seen when you DELETE stuff
- 3xx - redirects
  - 301/302 - permanent/temporary
- 4xx - client error
  - 400 Bad Request
    - syntax errors/validation errors
  - 401 Unauthorized - are not supplying any credentials / credentials are wrong
  - 403 Forbidden - authenticated, no access / no access at all
  - 404 Not Found
  - 405 Method Not Allowed    POST => endpoint that does not support POST
  - 415 MediaType Not Supprted  XML => endpoint that cannot/will not parse XML
  - 418 I'm a teapot
  - 422 Unprocessable Entity - logical reasons
- 5xx - server error
  - 500 Internal Server Error - exceptions
  - 502 Gateway Error

ASP.NET Core has 2 ways of creating such REST APIs:
- Controller-based
  - 2008 ASP.NET MVC
  - feature-complete
  - default structure
  - validation of incoming data `[Required]`
- Minimal APIs
  - 2021 .NET 6
  - no default structure
  - does not validate incoming data by default
    - FluentValidation
  - performance++
  - automatic documentation / more typesafety with return values

REST API - documentation
- OpenAPI
- Swagger

## API testing tools

- Postman
- curl
- Bruno
- Hoppscotch
- Insomnia
- VS Code extension
  - Thunder Client
  - REST client - .http .rest

## Talking to your Web API from your Blazor app

.NET's default choice: `HttpClient`. Comes with a few caveats though:

```cs
var products = await Http.GetFromJsonAsync<IEnumerable<Product>>("api/product");

// all good! but then:

await Http.PostAsJsonAsync();
//- no automatic JSON parsing for response
//- doesn't allow for easily setting header

await Http.PutAsJsonAsync()
// - no automatic JSON parsing for response
// - doesn't allow for easily setting header

await Http.DeleteAsJsonAsync()
// - doesn't allow for easily setting header

// often, manual sending is required:
await Http.SendAsync(new HttpRequestMessage() { });
// it's not uncommon to write helper methods/a wrapper class to extend the capabilities of HttpClient
```

Alternative: [Flurl](https://flurl.dev/)

```cs
var person = await "https://api.com"
    .AppendPathSegment("person")
    .SetQueryParams(new { a = 1, b = 2 })
    .WithOAuthBearerToken("my_oauth_token")
    .PostJsonAsync(new
    {
        first_name = "Claire",
        last_name = "Underwood"
    })
    .ReceiveJson<Person>();
```

## Blazor

- webframework
- SPA-webframework - Angular     Vue React Svelte Solid Qwik   "view library"
  - SPA: Single Page Application
    - high level of interaction with the user
    - it's all about user-friendlyness
- MPA-webframework - PHP Java Spring
- Microsoft
- 2020

SPA with Blazor
- WebAssembly   C# => compiles => WebAssembly
  - Web API "WebAssembly"
  - all your code runs in the browser
    - your code is talking to .NET bits
    - a microversion of .NET has to be shipped to the browser as well - Hello world-app is 7MB
- Server
  - all your code runs on the server
  - every click on a button gets communicated to the server. server will then recalculate the UI state and communicate that state back to the browser. that state then gets rendered.
  - on connection drop - your UI is completely unusable.

## Unit testing

Unit testing
- smallest bits of code

Integration testing
- integrating something
  - class A uses class B
  - including database
  - rendering HTML

End-to-end testing
- automating the browser
- navigating to a deployed application
- clicking/typing away in the UI

Test frameworks:
- MSTest - Microsoft  happy path
- NUnit
- xUnit

Mock frameworks:
- Moq
- NSubstitute
- FakeItEasy
