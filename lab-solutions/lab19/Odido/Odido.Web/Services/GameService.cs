using Odido.Web.Interfaces;
using Odido.Web.Models;

namespace Odido.Web.Services;

public class GameService : IGameService
{
    private readonly IOdidoApiClient odidoApiClient;

    public GameService(IOdidoApiClient odidoApiClient)
    {
        this.odidoApiClient = odidoApiClient;
    }
    public async Task<GameResponse> CreateGameAsync(string playerName, int difficulty = 1)
    {
        return await odidoApiClient.CreateGameAsync(playerName, difficulty) ?? throw new Exception("Failed to create game");
    }

    public async Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerNameAsync(string playerName)
    {
        return await odidoApiClient.GetActiveGamesByPlayerAsync(playerName) ?? throw new Exception("Failed to get active games");
    }

    public async Task<GameResponse?> GetGameByIdAsync(int id)
    {
        return await odidoApiClient.GetGameAsync(id) ?? throw new Exception("Failed to get game");
    }

    public async Task<GameActionResultResponse> PlayTurnAsync(int gameId, GameAction action)
    {
        return await odidoApiClient.PlayTurnAsync(gameId, action) ?? throw new Exception("Failed to play turn");
    }
}
