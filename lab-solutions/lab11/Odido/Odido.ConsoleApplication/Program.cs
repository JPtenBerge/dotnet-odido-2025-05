using Odido.ConsoleApplication;

Console.WriteLine("Enter your name, Hero:");
string playerName = Console.ReadLine() ?? "Hero";

Game game = new Game(playerName);

Console.WriteLine($"Welcome {game.PlayerName}!");

while (!game.IsCompleted)
{
    Console.WriteLine($"{game.Hero.Name}'s health: {game.Hero.Health}");
    Console.WriteLine($"{game.Boss.Name}'s health: {game.Boss.Health}");
    Console.WriteLine("What do you want to do next? [1: Attack, 2: Heal]");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int choice) || (choice != 1 && choice != 2))
    {
        Console.WriteLine("Invalid input. Please enter 1 for attack or 2 for heal.");
        continue;
    }

    GameAction action = (GameAction)(choice - 1);
    game.PlayTurn(action);

    Console.Clear();
    DisplayCombatLog(game);
}

Console.WriteLine($"{game.Hero.Name}'s health: {game.Hero.Health}");
Console.WriteLine($"{game.Boss.Name}'s health: {game.Boss.Health}");
Console.WriteLine($"Game Over. Winner: {game.WinnerType}");

void DisplayCombatLog(Game game)
{
    Console.WriteLine("Combat Log:");
    foreach (var entry in game.CombatLog)
    {
        Console.WriteLine($"{entry.Timestamp}: {entry.Message}");
    }
}

void Lab11() { 
    List<IDamageable> damageables = new List<IDamageable>
    {
        new Hero("Hero1"),
        new Boss("Boss1"),
        new Weapon()
    };
    foreach (var damageable in damageables)
    {
        damageable.TakeDamage(20);
        try
        {
            damageable.Heal();
        } catch (NotImplementedException)
        {
            Console.WriteLine($"{damageable.GetType().Name} cannot heal.");
        }
    }
}