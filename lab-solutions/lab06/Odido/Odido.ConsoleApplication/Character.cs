namespace Odido.ConsoleApplication;

internal class Character
{
    private const int MaxHealth = 100;

    public string Name { get; init; }
    public int Health { get; private set; }
    public bool IsAlive => Health > 0;

    public Character(string name, int initialHealth)
    {
        Name = name;
        Health = Math.Clamp(initialHealth, 0, MaxHealth);
    }

    public Character(string name) : this(name, MaxHealth) { }

    public int Attack(Character target)
    {
        int damage = Random.Shared.Next(10, 21);
        return target.TakeDamage(damage);
    }

    public int Heal()
    {
        int amount = Random.Shared.Next(5, 16);
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
        return amount;
    }

    private int TakeDamage(int damage)
    {
        int actualDamage = Math.Min(damage, Health);
        Health -= actualDamage;
        return actualDamage;
    }
}
