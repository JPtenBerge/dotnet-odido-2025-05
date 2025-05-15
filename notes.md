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