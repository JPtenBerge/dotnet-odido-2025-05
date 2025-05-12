namespace Odido.ConsoleApplication;

internal class GameService
{
    private readonly IGameRepository _repo;

    public GameService(IGameRepository repo)
    {
        _repo = repo;
    }

    public List<Game> GetGamesByPlayer(string playerName)
    {
        return _repo.GetActiveGamesForPlayer(playerName);
    }

    public Game CreateNewGame(string playerName)
    {
        var game = new Game(0, playerName);
        _repo.Create(game);
        return game;
    }

    public Game? GetGameById(int id)
    {
        return _repo.GetById(id);
    }

    public Game? PlayTurn(int gameId, GameAction action)
    {
        var game = _repo.GetById(gameId);
        if (game == null) return null;

        game.PlayTurn(action);
        _repo.Update(game);
        return game;
    }
}
