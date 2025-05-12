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
        int amount = Random.Shared.Next(5, 16);
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
        return amount;
    }
}
