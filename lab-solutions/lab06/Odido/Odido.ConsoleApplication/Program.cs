using Odido.ConsoleApplication;

Character hero = new Character("Hero");
Character boss = new Character("Boss", 120);

Console.WriteLine($"Welcome {hero.Name}!");
Console.WriteLine($"{hero.Name}'s health: {hero.Health}");
Console.WriteLine($"{boss.Name}'s health: {boss.Health}");
while (true)
{
    string? winner = PlayTurn(hero, boss);
    if (winner is not null)
    {
        Console.WriteLine($"Game Over. Winner: {winner}");
        break;
    }
}

string? PlayTurn(Character hero, Character boss)
{
    bool correctChoice = false;
    int choice;
    do {
        Console.WriteLine("What do you want to do next? [1: Attack, 2: Heal]");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out choice) || (choice != 1 && choice != 2))
        {
            Console.WriteLine("Invalid input. Please enter 1 for attack or 2 for heal.");
            correctChoice = false;
        } else
        {
            correctChoice = true;
        }
    } while(!correctChoice);

    GameAction heroAction = (GameAction)(choice - 1);

    if (heroAction == GameAction.Attack)
    {
        int damage = hero.Attack(boss);
        Console.WriteLine($"{hero.Name} attacks and deals {damage} damage!");
    }
    else
    {
        int healed = hero.Heal();
        Console.WriteLine($"{hero.Name} heals for {healed} health!");
    }

    if (!boss.IsAlive)
    {
        Console.WriteLine($"{boss.Name} has been defeated!");
        return hero.Name;
    }

    int bossDamage = boss.Attack(hero);
    Console.WriteLine($"{boss.Name} attacks and deals {bossDamage} damage!");

    if (!hero.IsAlive)
    {
        Console.WriteLine($"{hero.Name} has been defeated!");
        return boss.Name;
    }

    string summary = $"""
      Turn Summary:
        {hero.Name} HP: {hero.Health}
        {boss.Name} HP: {boss.Health}
      """;
    Console.WriteLine(summary);

    return null;
}