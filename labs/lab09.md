## Lab 09: Overriding Behavior – Smarter Boss Fights

---

### 🎯 Objective

In this lab, you'll use **polymorphism** to give the `Boss` class custom behavior:

- The `Boss` takes **less damage** the higher its level
- The `Boss` has a **dynamic max health** that scales with level

You'll accomplish this by using the `virtual` and `override` keywords.

---

### 🧱 Step 1: Add a Virtual MaxHealth

Your base `Character` class should have a property representing its `MaxHealth`.

Make this property `virtual`, and set a default value like `100`.

Then, override it in the `Boss` class. Its value should increase with the `Level`.

---

### 🧱 Step 2: Override TakeDamage in Boss

The base `Character.TakeDamage(int damage)` can be left as-is for now.

In the `Boss` class, **override** it.

Inside the method, scale the damage down using the Boss's `Level`.

For example: the higher the `Level`, the **less** damage should be taken.

> 💡 Consider using `Math.Max(1, damage * factor)` to prevent zero damage.

---

### ✅ Test and Observe

Once you've overridden the behavior:

- Run your game loop
- Check if the Boss receives reduced damage
- Check if the Boss has increased health if Level > 1

---

### ✅ Goals

- Understand how to override base behavior using `virtual` and `override`
- Practice upcasting: treat both `Hero` and `Boss` as `Character`
- Design flexible systems where behavior is specialized in subclasses
