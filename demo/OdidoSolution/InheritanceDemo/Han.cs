using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo;

class Game
{
}


internal class Hero(string name, Game game) : Character(name: name, game: game)
{
    
}

class Character(string name, Game game, int maxHealth = 100)
{
    public string Name { get; private set; } = name;
    public int Health { get; private set; } = maxHealth;
    public int MaxHealth { get; private set; } = maxHealth;
    public int? LastDamage { get; private set; }
    // private readonly List<StatusEffect> _statusEffects = [];
    public bool IsAlive => Health > 0;
    public override string ToString()
    {
        return $"{Name} health: {Health}";
    }
    public void Heal(int amount)
    {
        Health = Math.Clamp(Health + amount, 0, MaxHealth);
    }
    public void TakeDamage(int amount)
    {
        LastDamage = amount;
        Health = Math.Clamp(Health - amount, 0, MaxHealth);
    }
}
