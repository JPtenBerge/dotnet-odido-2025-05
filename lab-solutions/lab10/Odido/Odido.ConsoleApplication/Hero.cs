namespace Odido.ConsoleApplication;

internal class Hero : Character
{
    public Hero() : this("Hero")
    {
    }
    public Hero(string name) : base(name)
    {
        Type = "Hero";
    }
    public int Heal()
    {
        int amount = Random.Shared.Next(10, 21);
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
        return amount;
    }

    protected override int CalculateAttackDamage()
    {
        return Random.Shared.Next(5, 16);
    }
}
