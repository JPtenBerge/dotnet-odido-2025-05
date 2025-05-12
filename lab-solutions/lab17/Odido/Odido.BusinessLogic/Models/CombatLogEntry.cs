namespace Odido.BusinessLogic.Models;

public class CombatLogEntry
{
    public int Id { get; init; }
    public int GameId { get; init; }
    public string Message { get; }
    public DateTime Timestamp { get; }

    public CombatLogEntry(string message)
    {
        Message = message;
        Timestamp = DateTime.Now;
    }
    internal CombatLogEntry(int id, int gameId, string message, DateTime timestamp)
    {
        Id = id;
        GameId = gameId;
        Message = message;
        Timestamp = timestamp;
    }
}
