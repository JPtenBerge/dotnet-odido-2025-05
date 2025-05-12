# 🛠️ Lab 18: Building the Web API Controller

---

## 🎯 Objective

- Build a proper **Web API Controller**  
- Learn about **DTOs** (Data Transfer Objects)  
- Separate **internal models** from **external contracts**  
- Expose endpoints to create, list, retrieve, and play a game

---

## Step 1: Prepare the DTOs

✅ In your WebApi project:

- Create a new folder: **DTO**
- Add the following DTO classes:
  - `CreateGameRequest`
  - `PlayTurnRequest`
  - `GameResponse`
  - `CharacterResponse`
  - `GameActionResultResponse`

These classes define what data **clients** of your API will **send** and **receive**.

---

## Step 2: Map Models to DTOs

✅ Create another folder: **Extensions**

✅ Create a static class: `DTOModelMappers`

- Add an **extension method** `ToResponse()` that converts a `Game` model into a `GameResponse` DTO.

**Reminder**:  
An extension method:
- Is a `static` method inside a `static` class
- Has a `this` keyword in the first parameter

Example:
```cs
public static GameResponse ToResponse(this Game game) { ... }
```

✅ Place the method inside the `Odido.WebApi.Extensions` namespace.

✅ Use LINQ to project the `CombatLog` entries.

---

## Step 3: Build the Controller

✅ Create a **GameController** class:

- In the Controllers folder
- Decorate it with `[ApiController]` and `[Route("api/[controller]")]`

Inject the `GameService` into the constructor.

> (Optional, Bonus 🎁) Create an `IGameService` interface and inject by interface instead of concrete class!

---

## Step 4: Implement Endpoints

Inside `GameController`, add:

| HTTP Verb | URL                          | Action                      | Expected Body              |
|-----------|-------------------------------|------------------------------|-----------------------------|
| POST      | `/api/game`                   | Create a new game            | `CreateGameRequest`         |
| GET       | `/api/game/player/{playerName}`| Get active games for player  | none                        |
| GET       | `/api/game/{id}`               | Get game by ID               | none                        |
| POST      | `/api/game/{id}/play`          | Play a turn                  | `PlayTurnRequest`           |

✅ In each method:
- Call the corresponding method on `GameService`
- Map the result to a DTO using `.ToResponse()`
- Return an appropriate `ActionResult<>`

---

## Step 5: Try the API!

✅ Open the **Endpoints Explorer** in Visual Studio

✅ Generate a `.http` file to interact with your API.

You can use the following template:

```plaintext
@Odido.WebApi_HostAddress = https://localhost:xxxx

@playerName=Mario

### Get active games
GET {{Odido.WebApi_HostAddress}}/api/game/player/{{playerName}}

### Get game by ID
@id=1
GET {{Odido.WebApi_HostAddress}}/api/game/{{id}}

### Create new game
POST {{Odido.WebApi_HostAddress}}/api/game
Content-Type: application/json

{
  "PlayerName" : "{{playerName}}",
  "Difficulty": 1
}

### Play a turn - Attack
POST {{Odido.WebApi_HostAddress}}/api/game/{{id}}/play
Content-Type: application/json

{
  "Action" : 0
}

### Play a turn - Heal
POST {{Odido.WebApi_HostAddress}}/api/game/{{id}}/play
Content-Type: application/json

{
  "Action" : 1
}
```

✅ Tip:  
Make sure you're using the **HTTPS port** from your application URL!

---

## 🧠 Concepts Reinforced

✅ DTOs separate **internal models** from **external APIs**  
✅ Controllers focus on **routing and coordinating**, not business logic  
✅ **Extension methods** make model mapping clean  
✅ Practice **async/await** and **ActionResult<T>** patterns  
✅ Consolidate your three-tier architecture skills!

---

## 📁 Good Practice: Project Organization

✅ Keep a clean project structure:

- DTOs → `DTO` folder
- Mappers → `Extensions` folder
- Controllers → `Controllers` folder


---

## 📚 Need Help?

If you get stuck:
- Look into the **`lab-solutions/lab18/`** folder
- Check the working example provided
- Compare your code with the solution

