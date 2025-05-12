namespace Odido.BusinessLogic.Models;

public class Boss : Character
{
    public int Level { get; set; }
    public override int MaxHealth => maxHealth + Level* 20;
    public Boss() : this("Boss")
    {
    }
    public Boss(string name) : base(name)
    {
        Type = "Boss";
        Level = 1;
        Health = MaxHealth;
    }
    internal Boss(int id, int gameId, string name, int health, string type, int level) : base(id, gameId, name, health, type)
    {        
        Level = level;
    }

    public override int TakeDamage(int damage)
    {
        // Boss has damage reduction based on difficulty
        int reducedDamage = (int)Math.Max(1, damage * (1 - Level * 0.05));
        return base.TakeDamage(reducedDamage);
    }

    protected override int CalculateAttackDamage()
    {
        // Boss has a higher damage range based on level
        return Random.Shared.Next(5 + Level, 16 + Level);
    }
}
