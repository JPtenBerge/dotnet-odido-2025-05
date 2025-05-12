## Lab 10: Abstract Damage – Designing a Common Contract

---

### 🎯 Objective

You'll now refactor your `Character` class to be **abstract**, enforcing a common contract while allowing flexibility in subclasses.

Your goal is to move the **damage calculation** logic out of `Attack()` and into a new **abstract method**, implemented differently by `Hero` and `Boss`.

---

### 🧱 Step 1: Make Character Abstract

Mark the `Character` class as `abstract`.

Remember: abstract classes **cannot be instantiated directly**.

This reinforces the idea that `Character` is just a base concept.

---

### 🧱 Step 2: Add an Abstract Method

Declare an abstract `CalculateAttackDamage` method inside `Character` that should return an `int`.  
This will **force subclasses** to define how they compute damage.

---

### 🧱 Step 3: Update the Attack Logic

Inside the `Attack(Character target)` method:

- Call the `CalculateAttackDamage()` method to get the damage
- Then, call `target.TakeDamage(...)` as before

Now `Attack` uses the damage returned from the subclass.

---

### 🧱 Step 4: Implement It in Hero and Boss

- The `Hero` can return a fixed or random damage range
- The `Boss` can have a higher base damage or scaling based on `Level`

Keep it simple and experiment.

---

### ✅ Goals

- Understand how abstract classes **enforce structure**
- Implement a **shared algorithm** with flexible steps
- Prepare the foundation for adding more `Character` types in the future
