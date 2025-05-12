## Lab 05: Refactoring with Properties

---

### 🎯 Objective

In this lab, you'll take another step toward making your code cleaner and more maintainable - by using **properties**.

So far, you've hidden your character's internal data using private fields and exposed them through methods.  
Now, you'll refactor that logic using **properties** to make your class easier to use and more idiomatic in C#.

---

### 🛠 Step 1: Replace Backing Fields

Identify the private fields in your character class that are currently used with "getter" methods.  
Refactor those to use **auto-implemented properties** instead.

Make sure:
- External code can read the property
- Internal logic can still update it
- Validation still happens where necessary

---

### 🔒 Step 2: Use Access Modifiers

Use a **private `set`** where needed to protect the state from being modified externally.

Ask yourself:  
> “Should the rest of the program be allowed to change this value directly?”

If the answer is no - restrict access!

---

### 🧪 Step 3: Run Your Game

Update your game logic to use the new **properties** instead of methods or fields.

Check:
- Can you still read and print character health?
- Can your characters still attack and take damage?
- Does encapsulation still hold?

---

### ✅ Goals

- Understand the difference between **fields** and **properties**
- Replace method-based accessors with **C# properties**
- Use access modifiers to protect state
- Move one step closer to professional-quality C# code

> Properties are the standard way to expose data in .NET - now you're using them too!
