namespace Odido.ConsoleApplication;

internal class Character
{
    public const int MaxHealth = 100;

    public string Name { get; init; }
    public int Health { get; protected set; }
    public bool IsAlive => Health > 0;

    public string Type { get; set; }
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

    private int TakeDamage(int damage)
    {
        int actualDamage = Math.Min(damage, Health);
        Health -= actualDamage;
        return actualDamage;
    }
}
