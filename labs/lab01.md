## Lab 01: Your First RPG – Value Types Only

---

### 🎯 Objective

Build the very first working version of your RPG game - without classes, objects, or any advanced features.

You will:
- Use enums and value tuples
- Pass values by reference using `ref`
- Simulate a fight between two players using functions only
- Track health and turns with raw integers

---

### Step 1: Setup Game State

Create a new Console App.

In `Main()`, define:
- Two `int` variables: one for the hero's health, one for the boss's health (start both at 100)
- A loop that continues until one of the characters reaches 0 health

---

### Step 2: Create the Action Enum

Define an enum `GameAction` with two possible values:
- `Attack`
- `Heal`

Create a function that returns a random `GameAction`.

### 💡 Tip: use `Random.Shared.Next(0, 2)` to generate an int between 0 and 1
---

### Step 3: Write Game Logic Functions

Create **two functions**:
- One that simulates an **attack**, takes attacker and defender health as `ref`, and returns a value tuple containing the damage
- One that simulates a **heal**, takes health as `ref`, and returns a value tuple containing the amount healed

Try using:
- `ref` for modifying values
- Return an `(int, string)` tuple

---

### Step 4: Create a `PlayTurn` Function

Create a function `PlayTurn` that accepts:
- `ref int attackerHp`
- `ref int defenderHp`
- A `GameAction` value

The function should:
- Decide whether to call your `Attack` or `Heal` function based on the action
- Return a result that you can print or use in the main loop

---

### Step 5: Simulate the Game

Inside your loop:
- Call `PlayTurn` for the Hero's turn (Hero attacks/heals Boss)
- Call `PlayTurn` for the Boss's turn (Boss attacks/heals Hero)
- Print the current health values of both characters after each round

---

### Step 6: End the Game

When the loop ends, print who won:
- If hero health is 0, the boss wins
- If boss health is 0, the hero wins

No need to make it pretty - just print raw numbers and values.

---

### Bonus 🎁

Try these if you finish early:
- Add a function that returns both health and a `bool` saying if the character is still alive
- Create a function that uses an `out` parameter instead of a return value
- Make the game loop print how many turns it took before the game ended

---

### Recap

✅ You used only value types, functions, enums, and tuples  
✅ You passed variables with and without `ref`  
✅ You structured logic using methods and flow control  
✅ You wrote the **first functional prototype** of your RPG
