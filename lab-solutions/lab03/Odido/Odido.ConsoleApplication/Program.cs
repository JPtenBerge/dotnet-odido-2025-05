using Odido.ConsoleApplication;

Character hero = new Character();
Character boss = new Character();

Console.WriteLine("Welcome Hero!");
Console.WriteLine($"Hero's health: {hero.Health}");
Console.WriteLine($"Boss' health: {boss.Health}");
while (true)
{
    string? winner = PlayTurn(ref hero, ref boss);
    if (winner is not null)
    {
        Console.WriteLine($"Game Over. Winner: {winner}");
        break;
    }
}

string? PlayTurn(ref Character hero, ref Character boss)
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
        int damage = hero.Attack(ref boss);
        Console.WriteLine($"The hero attacks and deals {damage} damage!");
    }
    else
    {
        int healed = hero.Heal();
        Console.WriteLine($"The hero heals for {healed} health!");
    }

    if (!boss.IsAlive)
    {
        Console.WriteLine($"The boss has been defeated!");
        return "Hero";
    }

    int bossDamage = boss.Attack(ref hero);
    Console.WriteLine($"The boss attacks and deals {bossDamage} damage!");

    if (!hero.IsAlive)
    {
        Console.WriteLine($"The hero has been defeated!");
        return "Boss";
    }

    string summary = $"""
      Turn Summary:
        Hero HP: {hero.Health}
        Boss HP: {boss.Health}
      """;
    Console.WriteLine(summary);

    return null;
}