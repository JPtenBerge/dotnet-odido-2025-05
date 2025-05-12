## Lab 12: Applying SOLID Principles to the RPG Game

#### 🎯 Objective

In this lab, you'll refactor your RPG game engine to apply **three key SOLID principles**:

- 🧱 Interface Segregation (I)
- 🧍 Single Responsibility (S)
- 🔌 Dependency Inversion (D)

---

### Step 1 – Refactor Oversized Interfaces

Your current `IDamageable` interface also requires a `Heal()` method. But what if not all objects that can be damaged should be healed?

> ❗ This violates the **Interface Segregation Principle**

---

#### ✅ Split the interface

- Create two new interfaces:
  - `IDamageable` → with a method `int TakeDamage(int damage)`
  - `IHealable` → with a method `void Heal()`

- Update your classes accordingly:
  - `Character` should implement **only** `IDamageable`
  - `Hero` should implement **both**
  - `Weapon` should implement **only** `IDamageable`

---

### Step 2 – Introduce the GameService

Your `Program.cs` currently handles too many responsibilities.

> ❗ This violates the **Single Responsibility Principle**

---

#### ✅ Create a new class `GameService`

Move all game-related logic to this class:

- Store a list of current games (`Dictionary<int, Game>`)
- Implement the following methods:

```csharp
List<Game> GetGamesByPlayer(string playerName);
Game CreateNewGame(string playerName);
Game? GetGameById(int id);
Game? PlayTurn(int gameId, GameAction action);
```

> You may reuse or improve the existing code from `Program.cs`, but now it's organized in a clean service class.

---

### Step 3 – Abstract the Data Layer

Your `GameService` currently handles both game logic and persistence.

> ❗ That's a hidden dependency - let's invert it.

---

#### ✅ Create an Interface `IGameRepository`

Define the following methods:

```csharp
List<Game> GetActiveGamesForPlayer(string playerName);
Game? GetById(int gameId);
void Create(Game game);
void Update(Game game);
```

---

### Step 4 – Implement a Memory-Based Repository

- Create a class `InMemoryGameRepository` that implements `IGameRepository`
- It should use a simple in-memory list to store games

```csharp
private readonly Dictionary<int, Game> _games = new();
```

- Implement the interface methods accordingly
- Ensure that the repository assigns unique IDs to new games, which means the Game must now also have an `Id` property

---

### Step 5 – Inject the Repository into GameService

Update your `GameService` to accept a `IGameRepository` in its constructor:

```csharp
public GameService(IGameRepository repo)
{
    _repo = repo;
}
```

- Store the repo in a private field and use it inside your methods

> ✅ This is **Dependency Inversion** in practice!

---

### Step 6 – Wire Everything in `Program.cs`

Your `Program.cs` should now:

- Create an instance of `InMemoryGameRepository`
- Create an instance of `GameService`, passing in the repository
- Use the service to create/display/select/play games

```csharp
var repo = new InMemoryGameRepository();
var service = new GameService(repo);
```

> Later, you'll replace this with a real DI container (like ASP.NET does).

---

### 🧠 Bonus: Add More SRP Boundaries

Can you spot other classes doing too much?  
Can you break them up for testability and clarity?

Try:
- Separating Combat Logic into a new helper/service
- Moving user input logic away from business logic

---

### 🏁 Goal

✅ Interfaces are now clean and focused  
✅ Game logic is encapsulated in a proper service  
✅ Persistence is abstracted and injected  
✅ You've applied real SOLID principles - in a game! 🎮
