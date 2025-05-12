using Odido.Web.Interfaces;
using Odido.Web.Models;

namespace Odido.Web.HttpClients;

public class OdidoHttpClientStub : IOdidoApiClient
{
    public Task<GameResponse> CreateGameAsync(string playerName, int difficulty)
    {
        return Task.FromResult(GenerateRandomGameResponse(1));
    }

    public Task<IEnumerable<GameResponse>> GetActiveGamesByPlayerAsync(string playerName)
    {
        return Task.FromResult<IEnumerable<GameResponse>>(
        [
            GenerateRandomGameResponse(1, playerName),
            GenerateRandomGameResponse(2, playerName),
            GenerateRandomGameResponse(3, playerName),
            GenerateRandomGameResponse(4, playerName)
        ]);
    }

    public Task<GameResponse> GetGameAsync(int id)
    {
        return Task.FromResult(GenerateRandomGameResponse(id));
    }

    public Task<GameActionResultResponse> PlayTurnAsync(int id, GameAction action)
    {
        return Task.FromResult(GenerateRandomGameActionResultResponse(id,action));
    }

    private GameActionResultResponse GenerateRandomGameActionResultResponse(int id, GameAction action) {
        return new GameActionResultResponse
        {
            Game = GenerateRandomGameResponse(id),
            ActionMessage = action == GameAction.Attack ? "Hero Attacked Boss for 10 damage." : "Hero healed for 10 health points."
        };
    }

    private GameResponse GenerateRandomGameResponse(int id = 1, string playerName = "TestPlayer")
    {
        var heroHealth = Random.Shared.Next(0, 101);
        var bossHealth = Random.Shared.Next(0, 121);

        var CombatLog = new List<string>() { "Game Started" };

        for (int i = 0; i < 10; i++)
        {
            CombatLog.Add(i % 2 == 0 ? $"Hero Healed for {Random.Shared.Next(5, 16)} healthPoints" : $"Hero attacked Boss for {Random.Shared.Next(10, 21)} damage points");
            CombatLog.Add($"Boss attacked Hero for {Random.Shared.Next(10, 21)} damage points");
        }

        var Hero = new CharacterResponse
        {
            Health = heroHealth,
            MaxHealth = 100,
            IsAlive = heroHealth > 0,
            Type = "Hero"
        };
        var Boss = new CharacterResponse
        {
            Health = bossHealth,
            MaxHealth = 120,
            IsAlive = bossHealth > 0,
            Type = "Boss"
        };
        return new GameResponse
        {
            Id = id,
            PlayerName = playerName,
            CreationDate = DateTime.UtcNow,
            IsCompleted = !Hero.IsAlive || !Boss.IsAlive,
            WinnerType = Hero.IsAlive && !Boss.IsAlive ? "Hero" : Boss.IsAlive && !Hero.IsAlive ? "Boss" : null,
            Hero = Hero,
            Boss = Boss,
            CombatLog = CombatLog,
        };
    }
}
