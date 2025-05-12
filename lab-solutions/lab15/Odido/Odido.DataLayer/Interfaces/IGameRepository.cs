using Odido.DataLayer.Entities;

namespace Odido.DataLayer.Interfaces;

public interface IGameRepository
{
    List<Game> GetActiveGamesForPlayer(string playerName);
    Game? GetById(int gameId);
    Game Create(Game game);
    Game Update(Game game);
}
