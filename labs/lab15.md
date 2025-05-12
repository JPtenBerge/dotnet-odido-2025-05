# 🛠️ Lab 15: Moving Toward Three-Tier Architecture

---

## 🎯 Objective

Until now, everything has lived inside a single project.  
It's time to **reorganize** your solution to follow a **three-tier architecture** and prepare for real-world applications!

You will:

- Split your code into **Business Logic** and **Data Access**
- Introduce **Entities** vs **Models**
- Create **mapping methods** between layers
- Learn about **Extension Methods**
- Keep the app working exactly as before!

---

## 🧩 Step-by-Step Instructions

### 1. Create New Projects

- Right-click on the Solution ➡ **Add** ➡ **New Project**
- Create two **Class Library** projects:
  - `BusinessLogic`
  - `DataLayer`

You should now have three projects in your solution:
- **Console UI** (your original console app)
- **BusinessLogic**
- **DataLayer**

---

### 2. Organize Code into Folders

Create the following folders:

| Project        | Folders to Create         | Purpose                                |
|----------------|----------------------------|----------------------------------------|
| BusinessLogic  | `Models`, `Services`, `Extensions`, `Interfaces` | Business rules and logic            |
| DataLayer      | `Entities`, `Repositories`, `Interfaces` | Persistence layer: saving/loading |

✅ Create these folders now.

---

### 3. Move the Classes

Move your existing files as follows:

| Class or Interface               | Move To                    |
|-----------------------------------|-----------------------------|
| `Game`, `Character`, `Hero`, `Boss`, `CombatLogEntry`, `GameAction`, `Weapon` | `Models` folder (BusinessLogic) |
| `IGameRepository`                | `Interfaces` (DataLayer)    |
| `InMemoryGameRepository`         | `Repositories` (DataLayer)  |
| `GameService`                    | `Services` (BusinessLogic)  |
| `IDamageable`, `IHealable` | `Interfaces` (BusinessLogic)  |

✅ `Program.cs` stays in the **Console UI** project.

---

### 4. Fix Access Modifiers

Because you now have multiple projects:

- `internal` classes won't be visible outside their original project.
- 👉 **Change** all your important classes and interfaces to **public**.

---

### 5. Sync Namespaces

- Right-click the **Solution** ➡ **Sync Namespaces**.
- Visual Studio will fix the namespaces for you according to the folder structure.

✅ Much cleaner, much easier to maintain!

---

### 6. Add Project References

You need to link the projects:

- **Console UI** ➡ must reference ➡ **BusinessLogic**
- **BusinessLogic** ➡ must reference ➡ **DataLayer**

✅ Right-click on **Dependencies** ➡ **Add Project Reference** ➡ Select the correct project.

---

### 7. Understand Entities vs Models

You now need two versions of your core classes:

| Layer            | Purpose                            |
|------------------|------------------------------------|
| Models (BusinessLogic) | Contain logic and behavior (Attack, Heal, etc.) |
| Entities (DataLayer) | Only **data containers** (just properties) |

✅ Create in `Entities`:
- `GameEntity`
- `CharacterEntity`
- `HeroEntity`
- `BossEntity`
- `CombatLogEntryEntity`

✅ Each **Entity**:
- Has only public `{ get; set; }` properties
- Has an `Id` and a `GameId` where needed
- **No methods or logic**

---

### 8. Add `Id` and `GameId` to Models

In your `Game`, `Character`, `Hero`, `Boss`, and `CombatLogEntry` (in `BusinessLogic/Models`):

- Add `public Guid Id { get; set; }`
- Add `public Guid GameId { get; set; }` (where needed)

✅ Now Entities and Models have compatible fields!

---

### 9. Create Extension Methods for Mapping

To **convert** between Entities and Models easily, you'll use **Extension Methods**.

✅ Create a new static class `EntityModelMappers` in the `Extensions` folder.

---

#### 🔥 Important Tip to Simplify Your Mapping

Your Models have private fields and logic.  
**To make mapping easier**, do this:

✅ Add a **new constructor** to each Model (Character, Hero, Boss, Game, CombatLogEntry) that:

- Accepts **all necessary parameters** (Id, GameId, Health, Name, etc.)
- Fully initializes the object in one call

Example:

```cs
public Character(Guid id, Guid gameId, string name, int health)
{
    Id = id;
    GameId = gameId;
    Name = name;
    Health = health;
}
```

✅ Thanks to this, your `ToModel` mapping method becomes super easy:

```cs
public static Character ToModel(this CharacterEntity entity)
{
    return new Character(entity.Id, entity.GameId, entity.Name, entity.Health);
}
```

✅ You don't have to mess with private fields manually.

---

### 10. Update GameService

- When **saving** a game: Map the `Game` to a `GameEntity`
- When **loading** a game: Map the `GameEntity` back to a `Game`

✅ Always work with Models inside your Business Logic.  
✅ Let the Repository work with Entities.

---

### 11. Update InMemoryGameRepository

- Store a `List<GameEntity>` instead of `Game`
- Map between `Entity` and `Model` when loading/saving.

✅ The app stays working in memory - no database yet!

---

### 12. Final Test

✅ Run your app.  
✅ Play a game.  
✅ Save automatically after each turn.  
✅ Everything should work exactly as before!

---

# 🛟 Need Help?

A sample solution is available at:

```
lab-solutions/lab15
```

✅ Use it if you really get stuck - but **try first yourself** for maximum learning!

---

# 🎉 Congratulations!

You've just moved from a **basic app** ➡ **a real-world professional multi-project architecture**! 🚀  
You're building skills that **real C# developers** use daily!

