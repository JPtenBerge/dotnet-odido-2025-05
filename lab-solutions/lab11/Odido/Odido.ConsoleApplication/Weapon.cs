namespace Odido.ConsoleApplication;

internal class Weapon : IDamageable
{
    public int Heal()
    {
        throw new NotImplementedException();
    }

    public int TakeDamage(int damage)
    {
        Console.WriteLine($"Weapon taking {damage} damage...");
        return 10;
    }
}
