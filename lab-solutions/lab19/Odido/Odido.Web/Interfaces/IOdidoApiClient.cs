using Odido.Web.Models;

namespace Odido.Web.Interfaces;

public interface IOdidoApiClient
{
    Task<GameResponse> CreateGameAsync(string playerName, int difficulty);
    Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerAsync(string playerName);
    Task<GameResponse> GetGameAsync(int id);
    Task<GameActionResultResponse> PlayTurnAsync(int id, GameAction action);
}