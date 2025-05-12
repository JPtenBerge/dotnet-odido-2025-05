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

    public async Task<List<Game>> GetGamesByPlayer(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
            throw new ArgumentException("Player name cannot be null or empty.", nameof(playerName));
        var games = await _repo.GetActiveGamesForPlayer(playerName);
        return [..games.Select(g=>g.ToModel())];
    }

    public async Task<Game> CreateNewGame(string playerName)
    {
        var game = new Game(0, playerName);
        var gameEntity = await _repo.Create(game.ToEntity());
        game = gameEntity.ToModel();
        return game;
    }

    public async Task<Game?> GetGameById(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Game ID must be greater than zero.", nameof(id));
        var gameEntity = await _repo.GetById(id);
        return gameEntity?.ToModel();
    }

    public async Task<Game?> PlayTurn(int gameId, GameAction action)
    {
        if (gameId <= 0)
            throw new ArgumentException("Game ID must be greater than zero.", nameof(gameId));
        var gameEntity = await _repo.GetById(gameId);
        var game = gameEntity?.ToModel();
        if (game is null) return null;

        game.PlayTurn(action);
        gameEntity = await _repo.Update(game.ToEntity());
        game = gameEntity.ToModel();
        return game;
    }
}
