using Odido.Web.Models;

namespace Odido.Web.Interfaces;

public interface IGameService
{
    Task<GameResponse> CreateGameAsync(string playerName, int difficulty = 1);
    Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerNameAsync(string playerName);
    Task<GameResponse?> GetGameByIdAsync(int id);
    Task<GameActionResultResponse> PlayTurnAsync(int gameId, GameAction action);
}