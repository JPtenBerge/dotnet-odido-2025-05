### 🧪 Lab 14: ForEach<T> - Generic Delegate Utility

#### 🎯 Objective

You'll take what you built in the previous lab - a utility that loops over characters and applies actions - and make it work for **any type**, not just `Character`.

---

#### 🧠 Why This Matters

In real-world applications, reusing logic is critical. You don't want one method for characters, another for combat logs, another for weapons, etc. With **generics**, you can write the logic once and reuse it everywhere.

This lab will help you:

- Understand the basics of **generics**  
- Practice writing **generic methods**  
- Improve the flexibility and cleanliness of your code  

---

#### 🧩 Your Task

1. Take the helper method you created in the previous lab.
2. Change it so it can work with **any kind of item**, not just characters.
3. Create a version that:
   - Accepts a list of any type
   - Accepts a method that works on that type
4. Test your new generic method:
   - With a list of `Character`, as before
   - With a list of `CombatLogEntry` (print messages and timestamps)
   - With a list of `int` values (print whether each number is even or odd)

---

#### 🔁 Bonus Challenge

Try writing all your actions using **lambda expressions** instead of separate methods.

---

#### ✅ Goals

- Learn how to write a **generic method**
- Apply your logic to multiple types
- Explore the power of **reusability** in C#
