## Lab 06: Constructing Better Characters

---

### 🎯 Objective

You've been using your character class with hardcoded field values.  
It's time to improve that by introducing **constructors**.

This lab focuses on:
- Initializing objects with required values
- Using constructor overloading
- Exploring init-only properties for safer design

---

### 🛠 Step 1: Add a Constructor

Refactor your character class so it **requires a name and initial health** when created.

Ask yourself:
- Should a character be created without a name?
- Should a character always start with some health?

---

### 🧱 Step 2: Remove Parameterless Instantiation

Once your constructor is in place, try to remove the default ability to create a character without passing values.

Your goal:
> Ensure every character must be initialized with meaningful values.

---

### 🔁 Step 3: Overload the Constructor (Optional)

Allow users to create a character by just providing a name - in that case, default health to 100.

This makes your API flexible without giving up control.

---

### 🔐 Step 4: Try Init-only Properties (Optional)

If you want to make certain values **unchangeable after construction**, experiment with **init-only properties**.

For example:
- A character's name should never change
- Health might need to be updated, so leave it mutable

---

### ✅ Goals

- Use **constructors** to initialize your objects
- Use **overloaded constructors** to offer flexible defaults
- Experiment with **init-only properties** for immutability
- Reinforce the idea of **object consistency at creation**

> A well-constructed object is a healthy object - just like your Hero!

