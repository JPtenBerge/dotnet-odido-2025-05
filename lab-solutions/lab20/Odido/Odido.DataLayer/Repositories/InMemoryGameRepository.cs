using Odido.DataLayer.Entities;
using Odido.DataLayer.Interfaces;

namespace Odido.DataLayer.Repositories;

public class InMemoryGameRepository : IGameRepository
{
    private readonly Dictionary<int, Game> _games = new();

    public Task<List<Game>> GetActiveGamesForPlayer(string playerName)
    {
        return Task.FromResult(_games.Values.Where(g => g.PlayerName == playerName && !g.IsCompleted).ToList());
    }

    public Task<Game?> GetById(int gameId)
    {
        return Task.FromResult(_games[gameId]);
    }

    public Task<Game> Create(Game game)
    {
        int id = _games.Keys.Any() ? _games.Keys.Max() + 1 : 1;
        game.Id = id;
        _games.Add(game.Id, game);
        return Task.FromResult(game);
    }

    public Task<Game> Update(Game game)
    {
        // In-memory list automatically reflects changes to objects
        // No need to update the dictionary, but we can check if the game exists
        if (_games.ContainsKey(game.Id))
        {
            _games[game.Id] = game;
            return Task.FromResult(game);
        } else
        {
            throw new KeyNotFoundException($"Game with ID {game.Id} not found.");
        }
    }
}
