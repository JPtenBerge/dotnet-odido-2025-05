using Odido.Web.Interfaces;
using Odido.Web.Models;


namespace Odido.Web.HttpClients;

public class OdidoApiClient : IOdidoApiClient
{
    private readonly HttpClient httpClient;

    public OdidoApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    //url: "api/game", method POST, body: { playerName, difficulty }
    public async Task<GameResponse> CreateGameAsync(string playerName, int difficulty)
    {
        CreateGameRequest createGameRequest = new CreateGameRequest
        {
            PlayerName = playerName,
            Difficulty = difficulty
        };
        var response = await httpClient.PostAsJsonAsync("api/game", createGameRequest);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<GameResponse>();
    }

    //url: "api/game/player/{playerName}", method GET
    public async Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerAsync(string playerName)
    {
        var response = await httpClient.GetAsync($"api/game/player/{playerName}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<GameResponse>>();
    }

    //url: "api/game/{id}", method GET
    public async Task<GameResponse> GetGameAsync(int id)
    {
        var response = await httpClient.GetAsync($"api/game/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<GameResponse>();
    }

    //url: "api/game/{id}/play", method POST, body: { action }
    public async Task<GameActionResultResponse> PlayTurnAsync(int id, GameAction action)
    {
        PlayTurnRequest playTurnRequest = new PlayTurnRequest
        {
            Action = action
        };
        var response = await httpClient.PostAsJsonAsync($"api/game/{id}/play", playTurnRequest);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<GameActionResultResponse>();
    }

}
