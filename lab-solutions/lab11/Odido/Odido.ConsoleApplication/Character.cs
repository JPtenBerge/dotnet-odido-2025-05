namespace Odido.ConsoleApplication;

internal abstract class Character : IDamageable
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
        int damage = CalculateAttackDamage();
        return target.TakeDamage(damage);
    }

    protected abstract int CalculateAttackDamage();

    public virtual int TakeDamage(int damage)
    {
        int actualDamage = Math.Min(damage, Health);
        Health -= actualDamage;
        return actualDamage;
    }



    public virtual int Heal()
    {
        throw new NotImplementedException();
    }
}
