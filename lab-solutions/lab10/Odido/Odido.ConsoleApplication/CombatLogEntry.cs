namespace Odido.ConsoleApplication;

internal class CombatLogEntry
{
    public string Message { get; }
    public DateTime Timestamp { get; }

    public CombatLogEntry(string message)
    {
        Message = message;
        Timestamp = DateTime.Now;
    }
}
