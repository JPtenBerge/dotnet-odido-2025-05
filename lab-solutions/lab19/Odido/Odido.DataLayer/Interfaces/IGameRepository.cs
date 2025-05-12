using Odido.DataLayer.Entities;

namespace Odido.DataLayer.Interfaces;

public interface IGameRepository
{
    Task<List<Game>> GetActiveGamesForPlayer(string playerName);
    Task<Game?> GetById(int gameId);
    Task<Game> Create(Game game);
    Task<Game> Update(Game game);
}
