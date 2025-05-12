## Lab 02: Introducing Structs – Refactor Your RPG

<!-- .slide: class="is-lab" -->

---

### 🎯 Objective

Take your procedural turn-based game and **refactor it using `struct` types**.

You will:
- Create a `struct` to represent a `Character`
- Move health and behavior into the struct
- Let characters attack each other or heal themselves
- Observe how structs behave when copied

This is your first step toward **encapsulation** and better code organization.

---

### 🧱 Step 1: Create a Character Struct

Define a `struct Character` with:
- A field for `Health` (start at 100)
- A `bool IsAlive` property that returns `true` if `Health > 0`

---

### 🧠 Step 2: Add Behavior

Add two methods to the struct:
- One for `Attack(Character target)`
    - Generates a random damage value
    - Decreases the `target`'s health
    - Returns the damage as `int`
- One for `Heal()`
    - Increases the character's health by a random amount
    - Caps health at 100
    - Returns the amount healed as `int`

Think about:
- How does a struct pass data? What happens when you modify the `target` inside `Attack()`?

---

### 🧪 Step 3: Use the Struct in a Fight

Back in `Main()`:
- Declare two characters: `hero` and `boss`
- Use a `while` loop to alternate turns
- Let each character randomly choose between healing and attacking the opponent
- Update their health accordingly

Print out raw values for health after each turn (no formatting needed).

---

### 🔁 Step 4: Understand Value Semantics

Try this:

- Assign `hero` to a new variable called `copy`
- Call `Heal()` or `Attack()` on `copy`
- Print out both `hero` and `copy`'s health

You should notice: **the original didn't change**. Why?

Discuss:
> What's the difference between structs and classes?  
> Why is the target not affected unless passed with `ref`?

---

### ⚡ Bonus Challenges

If you finish early:

- Refactor `Attack()` to require `ref` for the `target`
- Add a `MaxHealth` constant in the struct and use it in `Heal()`
- Try using a nullable int `int? lastDamageTaken` as a field

---

### 🧠 Recap

✅ You created your first custom data type with `struct`  
✅ You encapsulated fields and methods together  
✅ You practiced value-based behavior and learned when `ref` is needed  
✅ You made your RPG more maintainable and realistic

