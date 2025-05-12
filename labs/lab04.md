## Lab 04: Introducing Encapsulation

---

### 🎯 Objective

Time to refactor your character system to make it more robust and safer.

You will begin applying the principle of **encapsulation**:
- Hide internal details of your character
- Expose only well-defined, safe ways to interact with it

---

### 🧱 Step 1: Convert to a Class

Change your existing character definition from a struct to a class.

Your character should now behave more like an object, with internal state and methods that encapsulate its logic.

---

### 🔐 Step 2: Encapsulate Health

Store the character's health internally and prevent direct access from the outside.

Provide a way for external code to **read** the current health, but **not modify** it directly.

---

### 🛡 Step 3: Add Damage Logic

Create a method that handles receiving damage.

It should:
- Prevent the health from going below zero
- Return how much damage was actually applied

Only this method should modify the character's health.

---

### ⚔️ Step 4: Add Attack Behavior

Add a method for the character to attack another character.

It should:
- Generate a random damage amount
- Ask the opponent to take damage
- Return the amount of damage actually applied

This introduces a **clear interaction pattern** between objects.

---

### ♻️ Step 5: Update Game Logic

Update your game loop to use the new class-based characters.

Use the methods you defined to:
- Get the current health
- Perform attacks

Replace any direct access to health with method calls.

---

### ✅ Goals

- Understand the purpose and benefits of **encapsulation**
- Use **access modifiers** to protect internal state
- Interact with objects through **clearly defined methods**
- Make your logic easier to maintain and evolve

