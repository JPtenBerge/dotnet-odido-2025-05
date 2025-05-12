namespace Odido.ConsoleApplication;

internal class Weapon : IDamageable
{
    public int Durability { get; private set; } = 100;

    public int TakeDamage(int damage)
    {
        int actualDamage = Math.Min(damage, Durability);
        Durability -= actualDamage;
        return actualDamage;
    }
}
