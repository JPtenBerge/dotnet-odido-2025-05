using Odido.BusinessLogic.Models;

namespace Odido.BusinessLogic.Interfaces;

public interface IGameService
{
    Task<Game> CreateNewGame(string playerName);
    Task<Game?> GetGameById(int id);
    Task<List<Game>> GetGamesByPlayer(string playerName);
    Task<Game?> PlayTurn(int gameId, GameAction action);
}