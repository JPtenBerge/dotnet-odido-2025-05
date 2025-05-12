## Lab 08: Creating Hero and Boss Classes - Practicing Inheritance

---

### 🎯 Objective

In this lab, you'll introduce **inheritance** by separating your game's logic into **specialized classes** for `Hero` and `Boss`.

Your `Character` class was fine for now - but it's time to refactor and make it more expressive and future-proof.

---

### 🧱 Step 1: Inherit from Character

Create two new classes:

- `Hero` : inherits from `Character`
- `Boss` : inherits from `Character`

Refactor your solution so you can now store a `Hero` and a `Boss` separately in the `Game` class.

Note: Your `Game.Characters` list should still store `Character` objects, so it can hold both.

---

### 🔧 Step 2: Move Heal to the Hero

The `Heal()` method only makes sense for the `Hero`.

Move it out of `Character` and implement it in the `Hero` class.

You may want to include `Random` logic inside this method to restore some amount of health.

---

### 🧪 Step 3: Add Fields and Constructors

1. In `Boss`, add a `Level` field/property - default to `1`
2. Add a **parameterless constructor** for both `Hero` and `Boss`
   - Hero → Name = `"Hero"`, Type = `"Hero"`
   - Boss → Name = `"Boss"`, Level = 1, Type = `"Boss"`

3. Add **custom constructors** that:
   - Accept values like name or level
   - Call the base constructor using `: base(...)`

Use `base(...)` to pass values to `Character`'s constructor.

---

### 🧪 Step 4: Update Game Class

Update the `Game` class to hold:

- A property `Hero` of type `Hero`
- A property `Boss` of type `Boss`

- Use `Characters.OfType<Hero>().First()` to get the hero
- Use `Characters.OfType<Boss>().First()` to get the boss

Create them in your game setup code (still inside `Program.cs` for now).

You should also still maintain the `List<Character> Characters` so you can use the game as before.

---

### ✅ Goals

- Practice basic inheritance syntax and class structure
- Learn how to use the `base(...)` keyword to pass data up the chain
- Keep your `Character` list flexible (base type), while using specific types where needed
