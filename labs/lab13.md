### 🧪 Lab 13: ForEachCharacter - Delegate-Based Utilities

#### 🎯 Objective
You'll build a small utility to apply different actions to all characters in a game. Instead of repeating the same loop over and over, you'll delegate the action and call it for each character.

---

#### 🧠 Why This Matters

In games (and in real-world apps), it's common to repeat logic like printing status, applying damage, healing, or logging actions. By writing a small utility that accepts a method as a parameter, you can reuse the loop without rewriting the logic each time.

This lab will help you:

- Learn how to **use delegates** to pass behavior
- Practice using **lambdas**
- Avoid repeating yourself

---

#### 🧩 Your Task

1. Define a type of method that accepts a character and returns nothing.
2. Write a helper method that:
   - Accepts a list of characters
   - Accepts one of those methods
   - Loops over each character and applies the method
3. Create a list with multiple characters (both Hero and Boss).
4. Try using the helper method to:
   - Print the character's type, name, and health
   - Apply 10 damage to each character
   - Print a motivational message using an inline lambda

---

#### 🧪 Experiment

Try swapping out the logic without changing the helper method. What happens when you reuse the loop with a completely different action?

---

#### ✅ Goals

- Practice working with delegates and lambdas
- See the value of reusing logic
- Prepare for building more generic utilities in the next lab

