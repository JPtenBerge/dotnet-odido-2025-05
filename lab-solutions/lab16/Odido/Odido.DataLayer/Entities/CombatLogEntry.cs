namespace Odido.DataLayer.Entities;

public class CombatLogEntry
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
