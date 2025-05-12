# 🛠️ Lab 16: Switching to Entity Framework Core

---

## 🎯 Objective

You've split your code into Business Logic and Data Layer.  
Now it's time to make your app **persist data in a real SQLite database** using **Entity Framework Core**!

You will:

- Add **Entity Framework Core** to your DataLayer
- Create a **DbContext**
- Implement a **new repository** that uses EF Core
- Initialize the database automatically
- Keep your application working - now with real persistence!

---

## 🧩 Step-by-Step Instructions

---

### 1. Install the Required Package

- Right-click on the `DataLayer` project ➡ **Manage NuGet Packages**
- Install:

```
Microsoft.EntityFrameworkCore.Sqlite
```

✅ This brings EF Core + SQLite support.

---

### 2. Create the `Data` Folder

In the `DataLayer` project:

✅ Create a new folder called `Data`.

---

### 3. Create the `OdidoDbContext`

Inside the `Data` folder:

✅ Add a new class: `OdidoDbContext`

- Inherit from `DbContext`
- Add `DbSet`s for:
  - `Games`
  - `Characters`
  - `CombatLogEntries`

Example (but don't copy-paste!):

```cs
public DbSet<GameEntity> Games { get; set; }
public DbSet<CharacterEntity> Characters { get; set; }
public DbSet<HeroEntity> Heroes { get; set; }
public DbSet<BossEntity> Bosses { get; set; }
public DbSet<CombatLogEntryEntity> CombatLogEntries { get; set; }
```

✅ Override `OnConfiguring` to connect to a local SQLite database file called `games.db`.

Example idea:

```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source=games.db");
}
```

✅ This way, you don't need full DI yet - the DbContext will configure itself!

---

### 4. Create the `EntityFrameworkGameRepository`

✅ Add a new class to the `Repositories` folder:  
`EntityFrameworkGameRepository`

✅ Implement the same `IGameRepository` interface you used before.

✅ This time:
- Create a **new `OdidoDbContext`** inside each method.
- Make sure to `.Include()` related data when loading a `Game`:
  - `Characters`
  - `CombatLogEntries`

✅ When you query for games, **only retrieve active games**:
- `IsCompleted == false`

---

### 5. Update `Program.cs` to Ensure Database Exists

Before using the repository:

✅ Add this line to create the database automatically:

```cs
using (var db = new OdidoDbContext())
{
    db.Database.EnsureCreated();
}
```

✅ This guarantees that the `games.db` file will be created the first time you run the app.

---

### 6. Replace the Repository

✅ Replace your `InMemoryGameRepository` with the new `EntityFrameworkGameRepository` when creating the `GameService` in `Program.cs`.

✅ The application **should work exactly the same**,  
✅ but **now saves the games permanently** in a SQLite file!

---

# 🧪 Optional Challenge (if you feel ready)

If you want to practice more real-world techniques:

✅ Make all repository methods **asynchronous**!

You will need to:

- Modify `IGameRepository` to use `Task<T>` or `Task`
- Update your `EntityFrameworkGameRepository` to use:
  - `.ToListAsync()`
  - `.FirstOrDefaultAsync()`
  - `.SaveChangesAsync()`
- Update `GameService` to call async methods
- Update `Program.cs` to use `async Main()` and `await`

✅ If you don't know how, no problem!

✅ Just make sure the **synchronous version works first**!

---

# 📝 Important Note

You may still have errors in your code when trying to update a Game on the Database. 
This is because the DbContext has a longer lifetime than it should.  
We will fix this in the next lab.


# 🛟 Need Help?

You can check the sample solution at:

```
lab-solutions/lab16
```

✅ But **try to solve it yourself first** for maximum practice!

---

# 🎉 Congratulations!

By completing this lab, you moved your app:

✅ From In-Memory ➡ To Real Database  
✅ From a Demo ➡ To Real-World Persistence  
✅ From Beginner ➡ To Professional Practice 🚀
