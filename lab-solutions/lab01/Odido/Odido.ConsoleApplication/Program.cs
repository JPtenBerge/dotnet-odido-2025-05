using Odido.ConsoleApplication;

int heroHealth = 100;
int bossHealth = 100;


while (heroHealth > 0 && bossHealth > 0)
{
    Console.WriteLine("Hero's Turn");
    GameAction heroMove = GetRandomAction();
    var (amount, log) = PlayTurn(ref heroHealth, ref bossHealth, heroMove);
    Console.WriteLine(log);
    

    Console.WriteLine($"Boss's Turn");
    GameAction bossMove = GetRandomAction();
    
    (amount, log) = PlayTurn(ref bossHealth, ref heroHealth, bossMove);
    Console.WriteLine(log);
    

    Console.WriteLine($"Hero HP: {heroHealth}, Boss HP: {bossHealth}");
    Console.WriteLine("------------------------------------");

}
if (heroHealth <= 0 && bossHealth <= 0)
    Console.WriteLine("Both characters are defeated!");
else if (heroHealth <= 0)
    Console.WriteLine("The boss wins!");
else
    Console.WriteLine("You win!");


GameAction GetRandomAction()
{
    return (GameAction)Random.Shared.Next(0, 2);
}


(int damage, string log) Attack(ref int attackerHp, ref int defenderHp)
{
    int damage = Random.Shared.Next(10, 21);
    defenderHp -= damage;
    return (damage, $"Attack did {damage} damage!");
}


(int heal, string log) Heal(ref int hp)
{
    int amount = Random.Shared.Next(5, 16);
    hp += amount;
    if (hp > 100) hp = 100;
    return (amount, $"Healed {amount} health!");
}


(int amount, string log) PlayTurn(ref int attackerHp, ref int defenderHp, GameAction gameAction)
{
    if (gameAction == GameAction.Attack)
    {
        return Attack(ref attackerHp, ref defenderHp);
    } else
    {
        return Heal(ref attackerHp);
    }
}