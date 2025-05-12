namespace Odido.ConsoleApplication;

internal class Character
{
    protected const int maxHealth = 100;

    public virtual int MaxHealth => maxHealth;

    public string Name { get; init; }
    public int Health { get; protected set; }
    public bool IsAlive => Health > 0;

    public string Type { get; set; }
    public Character(string name, int initialHealth)
    {
        Name = name;
        Health = Math.Clamp(initialHealth, 0, MaxHealth);
    }

    public Character(string name) : this(name, maxHealth) { 
        
    }

    public int Attack(Character target)
    {
        int damage = Random.Shared.Next(5, 16);
        return target.TakeDamage(damage);
    }

    protected virtual int TakeDamage(int damage)
    {
        int actualDamage = Math.Min(damage, Health);
        Health -= actualDamage;
        return actualDamage;
    }
}
