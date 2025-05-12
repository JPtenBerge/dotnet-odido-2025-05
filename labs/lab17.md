## Lab 17: Adding an ASP.NET Web API Project with Dependency Injection

---

### 🎯 Objective

Extend the turn-based game solution by adding an **ASP.NET Web API project**.

You'll:
- Add a new project to the solution
- Reference existing layers (Business Logic)
- Configure the **Dependency Injection container**
- Prepare to expose your game as a web API

> This lab connects everything you've done so far to the **ASP.NET application model**.

---

### 🧱 Step 1: Add the Web API Project

From the solution root:

```bash
dotnet new webapi -n Odido.WebApi
```

Or create it via Visual Studio:
- Choose **ASP.NET Core Web API**
- Remove the sample `WeatherForecast` controller

---

### 🔗 Step 2: Add References and Packages to Other Projects

- Make sure `WebApi` references `BusinessLogic`
- Add the `Microsoft.EntityFrameworkCore.Sqlite` NuGet package to `WebApi`

---

### 🧰 Step 3: Register Services in the DI Container

Open `Program.cs` in `WebApi`.  
Register your services:

```csharp
builder.Services.AddScoped<IGameRepository, EfGameRepository>();
builder.Services.AddScoped<GameService>();
builder.Services.AddDbContext<OdidoDbContext>(options =>
    options.UseSqLite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

### 🔑 Step 4: Configure the Database Connection

Open `appsettings.json` in `WebApi` and add a connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=game.db"
  }
}
```

> This is the same connection string you used in the `BusinessLogic` project.

---

### Step 5: Ensure the Database is Created

In Program.cs, add this line before `app.Run()`:

```csharp
// Create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GameDbContext>();
    dbContext.Database.EnsureCreated();
}
```

### 🧪 Step 6: Verify It Builds

Try running the Web API project:

You should see Kestrel starting and the app listening on a port.

There are no controllers yet - that comes in the next module!

---

### 🧠 Recap

- ✅ You added a **new ASP.NET Web API** project to your solution
- ✅ You referenced the **Business Logic** and **Shared** projects
- ✅ You registered your services in the **DI container**
- ✅ The solution now reflects a real **enterprise-style architecture**

---

### 🚀 Coming Up Next...

In the next chapter, you'll:

- Create actual API **controllers**
- Handle requests using your existing `GameService`
- Return data from your game via HTTPS
