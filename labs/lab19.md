# 🛠️ Lab 19: Blazor Pages and Components

---

## 🎯 Objective

- Build Blazor Pages and Components
- Connect the UI to a **Service** and a **Stubbed Client**
- Prepare the application to later connect to the real Web API
- Focus on **UI patterns**: Pages, Components, Services, Dependency Injection
- Practice keeping **UI code clean and modular**

---

## Step 1: Create the Blazor Project

✅ Create a new project:

- Template: **Blazor Web App**
- Framework: **.NET 9.0**
- Authentication: **None**
- HTTPS: ✅ Yes
- Render Mode: **Interactive Server**
- Interactivity Location: **Global**
- Include Sample Pages: ✅ Yes
- Top-level Statements: ❌ No
- Aspire Orchestration: ❌ No

---

## Step 2: Setup the Architecture

✅ This project is **self-contained** - it does NOT connect to the previous console app or Web API yet.

✅ Create the following folders:

- `Models`
- `Interfaces`
- `Services`
- `HttpClients`
- `Extensions` (later, optional for component helpers)

---

## Step 3: Prepare the Models

✅ Copy the **DTO** classes from your WebApi project into the new `Models` folder.

> 💬 **Note**: In theory, we should separate DTOs and Models here too, but to keep things simple we'll **reuse the DTOs** for now.

✅ Update the namespaces to match your new project.

---

## Step 4: Setup the Interfaces

✅ Create the `IGameService` interface:

```cs
public interface IGameService
{
    Task<GameResponse> CreateGameAsync(string playerName, int difficulty = 1);
    Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerNameAsync(string playerName);
    Task<GameResponse?> GetGameByIdAsync(int id);
    Task<GameActionResultResponse> PlayTurnAsync(int gameId, GameAction action);
}
```

✅ Create the `IOdidoApiClient` interface:

```cs
public interface IOdidoApiClient
{
    Task<GameResponse> CreateGameAsync(string playerName, int difficulty);
    Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerAsync(string playerName);
    Task<GameResponse> GetGameAsync(int id);
    Task<GameActionResultResponse> PlayTurnAsync(int id, GameAction action);
}
```

---

## Step 5: Create the Services and Stub

✅ Create the `GameService` class implementing `IGameService` (in `Services` folder)

```cs
using Odido.Web.Interfaces;
using Odido.Web.Models;

namespace Odido.Web.Services;

public class GameService : IGameService
{
    private readonly IOdidoApiClient odidoApiClient;

    public GameService(IOdidoApiClient odidoApiClient)
    {
        this.odidoApiClient = odidoApiClient;
    }
    public async Task<GameResponse> CreateGameAsync(string playerName, int difficulty = 1)
    {
        return await odidoApiClient.CreateGameAsync(playerName, difficulty) ?? throw new Exception("Failed to create game");
    }

    public async Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerNameAsync(string playerName)
    {
        return await odidoApiClient.GetActiveGamesByPlayerAsync(playerName) ?? throw new Exception("Failed to get active games");
    }

    public async Task<GameResponse?> GetGameByIdAsync(int id)
    {
        return await odidoApiClient.GetGameAsync(id) ?? throw new Exception("Failed to get game");
    }

    public async Task<GameActionResultResponse> PlayTurnAsync(int gameId, GameAction action)
    {
        return await odidoApiClient.PlayTurnAsync(gameId, action) ?? throw new Exception("Failed to play turn");
    }
}
```


✅ Create the `OdidoHttpClientStub` class implementing `IOdidoApiClient` (in `HttpClients` folder)

The **Stub** will return **fake data** for now so you can focus on **building the UI**!

```
using Odido.Web.Interfaces;
using Odido.Web.Models;

namespace Odido.Web.HttpClients;

public class OdidoHttpClientStub : IOdidoApiClient
{
    public Task<GameResponse> CreateGameAsync(string playerName, int difficulty)
    {
        return Task.FromResult(GenerateRandomGameResponse(1));
    }

    public Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerAsync(string playerName)
    {
        return Task.FromResult<IEnumerable<GameResponse>>(
        [
            GenerateRandomGameResponse(1, playerName),
            GenerateRandomGameResponse(2, playerName),
            GenerateRandomGameResponse(3, playerName),
            GenerateRandomGameResponse(4, playerName)
        ]);
    }

    public Task<GameResponse> GetGameAsync(int id)
    {
        return Task.FromResult(GenerateRandomGameResponse(id));
    }

    public Task<GameActionResultResponse> PlayTurnAsync(int id, GameAction action)
    {
        return Task.FromResult(GenerateRandomGameActionResultResponse(id,action));
    }

    private GameActionResultResponse GenerateRandomGameActionResultResponse(int id, GameAction action) {
        return new GameActionResultResponse
        {
            Game = GenerateRandomGameResponse(id),
            ActionMessage = action == GameAction.Attack ? "Hero Attacked Boss for 10 damage." : "Hero healed for 10 health points."
        };
    }

    private GameResponse GenerateRandomGameResponse(int id = 1, string playerName = "TestPlayer")
    {
        var heroHealth = Random.Shared.Next(0, 101);
        var bossHealth = Random.Shared.Next(0, 121);

        var CombatLog = new List<string>() { "Game Started" };

        for (int i = 0; i < 10; i++)
        {
            CombatLog.Add(i % 2 == 0 ? $"Hero Healed for {Random.Shared.Next(5, 16)} healthPoints" : $"Hero attacked Boss for {Random.Shared.Next(10, 21)} damage points");
            CombatLog.Add($"Boss attacked Hero for {Random.Shared.Next(10, 21)} damage points");
        }

        var Hero = new CharacterResponse
        {
            Health = heroHealth,
            MaxHealth = 100,
            IsAlive = heroHealth > 0,
            Type = "Hero"
        };
        var Boss = new CharacterResponse
        {
            Health = bossHealth,
            MaxHealth = 120,
            IsAlive = bossHealth > 0,
            Type = "Boss"
        };
        return new GameResponse
        {
            Id = id,
            PlayerName = playerName,
            CreationDate = DateTime.UtcNow,
            IsCompleted = !Hero.IsAlive || !Boss.IsAlive,
            WinnerType = Hero.IsAlive && !Boss.IsAlive ? "Hero" : Boss.IsAlive && !Hero.IsAlive ? "Boss" : null,
            Hero = Hero,
            Boss = Boss,
            CombatLog = CombatLog,
        };
    }
}
```

> 💬 **Note**: This stub will help you visualize the data without needing to connect to the Web API yet.

---

## Step 6: Configure Dependency Injection

✅ Open `Program.cs`

✅ Register your services:

```cs
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IOdidoApiClient, OdidoHttpClientStub>();
```

✅ This way Blazor will inject them into your pages!

---

## Step 7: Implement the Home Page

✅ Open the existing `Home.razor` page (under `Pages`)

✅ Implement the following features:

- Input box bound to a `PlayerName` string
- Button that calls `GetActiveGamesByPlayerNameAsync`
- List of active games displayed under the button

✅ For now, **inject** `IGameService` into the page:

```cs
@inject IGameService GameService
```

✅ Create simple UI to display:

- Game ID
- Creation Date
- Health (Hero & Boss)
- A **link or button** to *Play* the selected Game

✅ Create a **"New Game"** button to create a new game and navigate to Play page.

✅ Use `NavigationManager` to navigate:

```cs
@inject NavigationManager Navigation

Navigation.NavigateTo($"/play/{gameId}");
```

---

## Step 8: Implement the PlayGame Page

✅ Create a new Razor Page: `PlayGame.razor`

✅ Setup Route:

```cs
@page "/play/{id:int}"
```

✅ Inject `IGameService` to load the Game by ID.

✅ Features to build:

- Display **Hero** and **Boss** health
- Buttons to **Attack** and **Heal**
- Button to **Go back** to Home

✅ After each action, reload the updated game.

✅ Bonus: Use the **ActionMessage** to show the result of each attack or heal!

---

## Step 9: Bonus – Components

✅ Optional but strongly recommended!

- Create a `GameCard.razor` component to display a Game nicely
- Create a `HealthBar.razor` component to display Character health visually

✅ Put their styles in separate `.razor.css` files!

✅ Use Parameters:

```cs
[Parameter] public GameResponse Game { get; set; } = default!;
```

✅ Call your components from the Pages!

---

## Step 10: Run the App

✅ Try to:

- Enter a player name
- Load active games
- Click *Play* on a game
- Attack and Heal on the Play page
- Go back to Home

✅ See the fake data update!

---

## 📁 Good Practice: Structure

✅ Keep everything organized:

| Folder | What Goes In |
|--------|--------------|
| Models | GameResponse, CharacterResponse, etc |
| Interfaces | IGameService, IOdidoApiClient |
| Services | GameService |
| HttpClients | OdidoHttpClientStub |
| Pages | Home.razor, PlayGame.razor |
| Components (Optional) | GameCard, HealthBar, etc |

✅ After moving files, you can right-click **Solution → Sync Namespaces** to fix namespaces automatically!

---

## 📚 Need Help?

If you get stuck:
- Check the working example under **lab-solutions/lab19/**
- Compare your project structure with the provided solution

