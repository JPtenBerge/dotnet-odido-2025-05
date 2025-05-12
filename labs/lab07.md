## Lab 07: Introducing the Game Class - Abstraction in Action

---

### 🎯 Objective

It's time to **encapsulate the game state and logic** in a proper class.

You will define a `Game` class that represents a full play session - storing characters, history, and the logic to play a turn.

This lab puts your new abstraction skills to work.

---

### 🧱 Step 1: Build the Game Class

Define a `Game` class with the following **state**:

- The **player name**
- The **creation date**
- A flag: `IsCompleted`
- A field: `WinnerType` (string?)
- A list of `Character` objects
- A list of `CombatLogEntry` objects

Also add two **convenience properties**:
- `Hero` → return the `Hero` in the list
- `Boss` → return the `Boss` in the list

---

### 🪵 Step 2: Define the CombatLogEntry Class

A simple class to track what happened and when:

- A `string Message`
- A `DateTime Timestamp`

Create one at game start that says `"Game started"`.

---

### 🕹 Step 3: Add a PlayTurn Method

Inside the `Game` class, add a method called `PlayTurn(GameAction action)`.

This method should:
1. Let the **hero** perform the chosen action (attack or heal)
2. Add a combat log message for what happened
3. Check if the **boss** is dead:
   - If yes, mark the game as complete and set the winner
4. If not, let the **boss attack the hero**
5. Add a combat log message for that too
6. Check if the **hero** is dead:
   - If yes, mark the game as complete and set the winner

The method should return a `bool` indicating whether the game is now complete.

---

### 🧪 Step 4: Use the Game in Your Loop

Back in `Program.cs`, create a new `Game`, store characters and log, then use `PlayTurn()` for each round.

Use `while (!game.IsCompleted)` to loop.

---

### ✨ Bonus Step

Use the combat log to display what happened each turn. Print the last added message.

You still don't need fancy formatting - raw output is fine.

---

### ✅ Goals

- Move logic into a **domain class** instead of `Program.cs`
- Practice **abstraction** and class design
- Hide complexity behind a clean interface
- Keep evolving your game's structure

> Your code is becoming more expressive, reusable, and easier to maintain.
