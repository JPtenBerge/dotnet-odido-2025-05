## Lab 11: Shared Contracts with Interfaces

#### 🎯 Objective

Introduce interfaces as a way to define **shared contracts**.  
You'll create a common interface to represent things that can **take damage** and **be healed**... even if that doesn't make sense for every class (on purpose!).

This lab sets the stage for a future lesson on the **Interface Segregation Principle** in SOLID.

---

#### Step 1 – Define the Interface

Create an interface named `IDamageable` with two members:

- `int TakeDamage(int damage)`
- `void Heal()`

> 💡 This interface is intentionally **too big** - you'll improve it later.

---

#### Step 2 – Implement the Interface in Character

Update the `Character` class to implement `IDamageable`.

- Your class should:
  - Implement `TakeDamage` with its current logic
  - Implement `Heal` with its current logic (if applicable)

---

#### Step 3 – Create a New Class: Weapon

Add a class named `Weapon` to your solution.

- It should implement `IDamageable`
- The `TakeDamage(int damage)` method can simply log or store that it took damage
- For now, **throw a `NotImplementedException`** in the `Heal()` method

```csharp
throw new NotImplementedException("Weapons cannot be healed.");
```

> 💡 This is *intentional friction*. You'll understand why this matters when you learn about SOLID later.

---

#### Step 4 – Add a Collection of Damageable Objects

In your `Game` class or in the `Program.cs`, experiment with this idea:

- Create a `List<IDamageable>` containing a `Hero`, a `Boss`, and a `Weapon`
- Loop through the list and call `TakeDamage(10)` on each item

Optional:
- Try to call `Heal()` on each item. What happens?

---

#### 🧠 Reflection

> Think about it: Does it make sense that a **Weapon** has to implement `Heal()`?

You're experiencing the reason we have the **Interface Segregation Principle**.  
But don't fix it now - we'll improve this in a future chapter once you learn SOLID.

---

#### 🏁 Goal

✅ Practice declaring and implementing interfaces  
✅ Work with lists of mixed types via interface references  
✅ Discover the problems caused by oversized interfaces  
✅ Prepare for the SOLID principles coming up next