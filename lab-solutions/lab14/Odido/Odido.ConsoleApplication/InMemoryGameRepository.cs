namespace Odido.ConsoleApplication;

internal class InMemoryGameRepository : IGameRepository
{
    private readonly Dictionary<int, Game> _games = new();

    public List<Game> GetActiveGamesForPlayer(string playerName)
    {
        return _games.Values.Where(g => g.PlayerName == playerName && !g.IsCompleted).ToList();
    }

    public Game? GetById(int gameId)
    {
        return _games[gameId];
    }

    public void Create(Game game)
    {
        int id = _games.Keys.Any() ? _games.Keys.Max() + 1 : 1;
        game.Id = id;
        _games.Add(game.Id, game);
    }

    public void Update(Game game)
    {
        // In-memory list automatically reflects changes to objects
    }
}
