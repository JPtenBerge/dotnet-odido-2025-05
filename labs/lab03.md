## Lab 03: Talking to the User – Game Turns and String Interpolation

---

### 🎯 Objective

Make your RPG interactive by allowing the **player to choose their move** each turn - **Attack or Heal** - and improve your output using **string interpolation**.

You'll also:
- Practice `enum` handling for choices
- Use `Console.ReadLine()` to get input from the player
- Use `$""` and `"""` for better formatting

---

### 🛠 Step-by-step Instructions

---

### 🧱 Step 1: Declare GameAction

Make sure your enum from before is in place:

```cs
enum GameAction { Attack, Heal }
```

---

### 🧠 Step 2: Create the PlayTurn Method

Write a method `GameAction? PlayTurn(ref Character hero, ref Character boss)`.

This method should:

- Ask the user what they want to do (Attack or Heal)
- Parse their input into a `GameAction`
- Execute the Hero's action based on their choice
- Check if the Boss is dead → return the string "Hero" (Hero wins)
- If Boss is still alive, have the Boss automatically Attack
- Check if the Hero is dead → return the string "Boss" (Boss wins)
- Otherwise, return `null` to continue

You may break this down into smaller methods if you want.

---

### 🧪 Step 3: Format Your Strings

Use `$""` to write **friendly messages** like:

```cs
$"The hero attacks and deals {damage} damage!"
$"The boss has {boss.Health} HP left."
$"What do you want to do next? [attack/heal]"
```

If you want to try a **multiline interpolated string**, go ahead:

```cs
string summary = $"""
  Turn Summary:
    Hero HP: {hero.Health}
    Boss HP: {boss.Health}
  """;
Console.WriteLine(summary);
```

---

### 🧪 Step 4: Handle User Input

Prompt the user to choose `1` for attack or `2"` for heal, using:

```cs
string? input = Console.ReadLine();
```

and then try parsing it into a `GameAction` enum.
If the input is invalid, show a message like:

```cs
Console.WriteLine("Invalid input. Please enter 1 for attack or 2 for heal.");
```

---

### 🔁 Step 5: Loop Until Winner

Use a `while` loop to play turns until the method `PlayTurn()` returns a winner

---

### ⚡ Bonus Challenge

- Add a `TurnNumber` counter and display it every turn
- Display a final message: `"Game Over. Winner: {winner}"`

---

### 🧠 Recap

✅ You used **input and output** to interact with the user  
✅ You formatted strings using **$ interpolation**  
✅ You encapsulated turn logic in a method  
✅ You started building the **real turn-based flow**

