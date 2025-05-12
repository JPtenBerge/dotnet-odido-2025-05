namespace Odido.Web.Models;

public class CreateGameRequest
{
    public string PlayerName { get; set; } = string.Empty;
    public int Difficulty { get; set; } = 1;
}

public class PlayTurnRequest
{
    public GameAction Action { get; set; }
}
