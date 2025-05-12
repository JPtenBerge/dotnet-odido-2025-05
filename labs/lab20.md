# 🚀 Lab 20: Connecting Blazor to Your Web API

---

## 🎯 Objective

- Replace the **Stub** with a **real Typed HttpClient**
- Connect your Blazor WebApp to your real Web API
- Practice safe and efficient `HttpClient` usage
- Finally play your RPG game *for real*!

---

## Step 1: Create a Typed HttpClient

✅ Create a new class implementing the `IOdidoApiClient` interface you already have.

✅ This time, instead of returning fake data, the class will:

- Receive an `HttpClient` through constructor injection
- Use it to **make real HTTP calls** to your Web API

✅ Tip: You can use the following helpers:

```cs
await http.GetFromJsonAsync<T>();
await http.PostAsJsonAsync(url, obj);
await http.DeleteAsync(url);
await response.Content.ReadFromJsonAsync<T>();
```

✅ Remember to keep everything **asynchronous**!

---

## Step 2: Register Your Typed HttpClient

✅ Open `Program.cs` in your Blazor Web project.

✅ Remove the registration of the `OdidoHttpClientStub`.

✅ Instead, register your new **Typed HttpClient**:

```cs
builder.Services.AddHttpClient<IOdidoApiClient, OdidoHttpClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7287/"); // Replace with your actual Web API address!
});
```

✅ If you're not sure which port to use, check the address your WebApi project runs on.  
(Usually visible when you start it in Visual Studio.)

✅ Remember to **use HTTPS**!

---

## Step 3: Configure Multiple Startup Projects

✅ To play your game, you now need:

- **Odido.WebApi** (your Web API)
- **Odido.Web** (your Blazor WebApp)

✅ In Visual Studio:

- Right-click on the Solution
- Go to **Properties**
- Set **Startup Projects** to **Multiple**
- Select **Start** on both **WebApi** and **Web**

✅ Now when you run the solution, *both projects* will start automatically!

---

## Step 4: Test the Connection

✅ Start your solution.

✅ On your Home page:

- Search for your player name
- Create a new game
- Play!

✅ The data should now come **from the real Web API**, not from fake random stub data.

---

## 💡 Tips

- Catch errors in your HttpClient calls with `try-catch`
- Show friendly error messages if something goes wrong
- Remember that the game state now **persists** between requests!

✅ (You are using Entity Framework and SQLite in your WebApi!)

---

## 🎯 Goals

✅ Practice safe `HttpClient` usage  
✅ Learn to structure real-world client-to-server communication  
✅ Experience a real **full-stack** C# web app!  

---

# 🎉 Congratulations!!

You did it!  
You built a real, multi-tier, database-powered, full-stack **Blazor + WebAPI + EntityFramework** RPG application!

Take a moment to celebrate:  
- You wrote C# backend logic
- You designed Web APIs
- You called them safely from a Blazor app
- You built a full journey, step by step!

You should be **very proud** of yourself.

---

# 🎮 Go Play!

Your RPG game is ready.  
Go defeat some Bosses, Heal your Heroes, and dominate the Arena!

You earned it. 🌟🏆🎉

(And don't forget: **this is just the beginning** of your journey as a .NET developer.)
