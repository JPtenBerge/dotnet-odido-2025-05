using Odido.BusinessLogic.Models;
using Odido.BusinessLogic.Extensions;
using Odido.DataLayer.Interfaces;
namespace Odido.BusinessLogic.Services;

public class GameService
{
    private readonly IGameRepository _repo;

    public GameService(IGameRepository repo)
    {
        _repo = repo;
    }

    public List<Game> GetGamesByPlayer(string playerName)
    {
        return [.._repo.GetActiveGamesForPlayer(playerName).Select(g=>g.ToModel())];
    }

    public Game CreateNewGame(string playerName)
    {
        var game = new Game(0, playerName);
        game = _repo.Create(game.ToEntity()).ToModel();
        return game;
    }

    public Game? GetGameById(int id)
    {
        return _repo.GetById(id)?.ToModel();
    }

    public Game? PlayTurn(int gameId, GameAction action)
    {
        var game = _repo.GetById(gameId)?.ToModel();
        if (game is null) return null;

        game.PlayTurn(action);
        game = _repo.Update(game.ToEntity()).ToModel();
        return game;
    }
}
