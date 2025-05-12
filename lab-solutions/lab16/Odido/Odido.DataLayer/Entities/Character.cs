namespace Odido.DataLayer.Entities;

public abstract class Character 
{
    public int Id { get; set; }
    public int GameId { get; set; }

    public int MaxHealth { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Health { get; set; }
}
