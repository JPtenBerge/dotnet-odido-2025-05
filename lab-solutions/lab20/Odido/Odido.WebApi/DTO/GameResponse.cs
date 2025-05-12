namespace Odido.WebApi.DTO;

public class GameResponse
{
    public int Id { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public bool IsCompleted { get; set; }
    public string? WinnerType { get; set; }

    public CharacterResponse Hero { get; set; } = new CharacterResponse();
    public CharacterResponse Boss { get; set; } = new CharacterResponse();

    public List<string> CombatLog { get; set; } = [];
}

public class CharacterResponse
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public bool IsAlive { get; set; }
    public string Type { get; set; } = string.Empty;
}

public class GameActionResultResponse
{
    public GameResponse Game { get; set; } = new GameResponse();
    public string ActionMessage { get; set; } = string.Empty;
}

