using Odido.DataLayer.Entities;
using Odido.DataLayer.Interfaces;

namespace Odido.DataLayer.Repositories;

public class InMemoryGameRepository : IGameRepository
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

    public Game Create(Game game)
    {
        int id = _games.Keys.Any() ? _games.Keys.Max() + 1 : 1;
        game.Id = id;
        _games.Add(game.Id, game);
        return game;
    }

    public Game Update(Game game)
    {
        // In-memory list automatically reflects changes to objects
        // No need to update the dictionary, but we can check if the game exists
        if (_games.ContainsKey(game.Id))
        {
            _games[game.Id] = game;
            return game;
        } else
        {
            throw new KeyNotFoundException($"Game with ID {game.Id} not found.");
        }
    }
}
