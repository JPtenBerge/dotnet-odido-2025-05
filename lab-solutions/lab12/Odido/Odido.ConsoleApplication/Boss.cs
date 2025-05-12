namespace Odido.ConsoleApplication;

internal class Boss : Character
{
    public int Level { get; set; }
    public override int MaxHealth => maxHealth + (Level* 20);
    public Boss() : this("Boss")
    {
    }
    public Boss(string name) : base(name)
    {
        Type = "Boss";
        Level = 1;
        Health = MaxHealth;
    }
    public override int TakeDamage(int damage)
    {
        // Boss has damage reduction based on difficulty
        int reducedDamage = (int)Math.Max(1, damage * (1 - (Level * 0.05)));
        return base.TakeDamage(reducedDamage);
    }

    protected override int CalculateAttackDamage()
    {
        // Boss has a higher damage range based on level
        return Random.Shared.Next(5 + Level, 16 + Level);
    }
}
