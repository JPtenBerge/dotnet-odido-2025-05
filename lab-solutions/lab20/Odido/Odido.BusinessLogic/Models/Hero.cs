using Odido.BusinessLogic.Interfaces;

namespace Odido.BusinessLogic.Models;

public class Hero : Character, IHealable
{
    public Hero() : this("Hero")
    {
    }
    public Hero(string name) : base(name)
    {
        Type = "Hero";
    }
    internal Hero(int id, int gameId, string name, int health, string type) : base(id, gameId, name, health, type)
    {
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
