namespace Odido.DataLayer.Entities;

public class Game
{
    public int Id { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public bool IsCompleted { get; set; }
    public string? WinnerType { get; set; }
    public List<Character> Characters { get; set; } = [];
    public List<CombatLogEntry> CombatLog { get; set; } = [];

    public Hero Hero => Characters.OfType<Hero>().First();
    public Boss Boss => Characters.OfType<Boss>().First();
}
