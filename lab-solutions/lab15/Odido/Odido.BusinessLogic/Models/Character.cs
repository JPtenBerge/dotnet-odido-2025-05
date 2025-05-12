using Odido.BusinessLogic.Interfaces;

namespace Odido.BusinessLogic.Models;

public abstract class Character : IDamageable
{
    public int Id { get; init; }
    public int GameId { get; init; }
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
        Type = GetType().Name;
    }

    public Character(string name) : this(name, maxHealth)
    {

    }

    internal Character(int id, int gameId, string name, int health, string type) 
    {
        Id = id;
        GameId = gameId;
        Name = name;
        Health = health;
        Type = type;
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
}
