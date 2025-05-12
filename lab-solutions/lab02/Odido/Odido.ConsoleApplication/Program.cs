using Odido.ConsoleApplication;

Character hero = new Character();
Character boss = new Character();

while (hero.IsAlive && boss.IsAlive)
{
    Console.WriteLine("Hero's Turn");
    GameAction heroMove = GetRandomAction();
    if (heroMove == GameAction.Attack)
    {
        int damage = hero.Attack(ref boss);
        Console.WriteLine($"Hero attacks for {damage} damage!");
    }
    else
    {
        int healed = hero.Heal();
        Console.WriteLine($"Hero heals for {healed} health!");
    }

    if (!boss.IsAlive) break;

    Console.WriteLine("Boss's Turn");
    GameAction bossMove = GetRandomAction();
    if (bossMove == GameAction.Attack)
    {
        int damage = boss.Attack(ref hero);
        Console.WriteLine($"Boss attacks for {damage} damage!");
    }
    else
    {
        int healed = boss.Heal();
        Console.WriteLine($"Boss heals for {healed} health!");
    }

    Console.WriteLine($"Hero HP: {hero.Health}, Boss HP: {boss.Health}");
    Console.WriteLine("------------------------------------");
}

if (!hero.IsAlive && !boss.IsAlive)
    Console.WriteLine("Both characters are defeated!");
else if (!hero.IsAlive)
    Console.WriteLine("The boss wins!");
else
    Console.WriteLine("You win!");

GameAction GetRandomAction()
{
    return (GameAction)Random.Shared.Next(0, 2);
}