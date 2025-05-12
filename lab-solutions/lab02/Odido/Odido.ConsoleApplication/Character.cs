namespace Odido.ConsoleApplication;

internal struct Character
{
    private const int MaxHealth = 100;
    public int Health { get; private set; }
    public bool IsAlive => Health > 0;

    public Character()
    {
        Health = MaxHealth;
    }

    public int Attack(ref Character target)
    {
        int damage = Random.Shared.Next(10, 21);
        target.Health -= damage;
        if (target.Health < 0) target.Health = 0;
        return damage;
    }

    public int Heal()
    {
        int amount = Random.Shared.Next(5, 16);
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
        return amount;
    }
}
