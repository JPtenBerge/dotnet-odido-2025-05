namespace Odido.ConsoleApplication;

internal class Character
{
    private const int MaxHealth = 100;
    private int _health;
    public int Health => _health;
    public bool IsAlive => _health > 0;

    public Character()
    {
        _health = MaxHealth;
    }

    public int Attack(Character target)
    {
        int damage = Random.Shared.Next(10, 21);
        return target.TakeDamage(damage);
    }

    public int Heal()
    {
        int amount = Random.Shared.Next(5, 16);
        _health += amount;
        if (_health > MaxHealth) _health = MaxHealth;
        return amount;
    }

    private int TakeDamage(int damage)
    {
        int actualDamage = Math.Min(damage, _health);
        _health -= actualDamage;
        return actualDamage;
    }
}
