using Odido.BusinessLogic.Models;
using Odido.WebApi.DTO;

namespace Odido.WebApi.Extensions;

public static class DTOModelMappers
{
    public static GameResponse ToResponse(this Game game)
    {
        return new GameResponse
        {
            Id = game.Id,
            PlayerName = game.PlayerName,
            CreationDate = game.CreationDate,
            IsCompleted = game.IsCompleted,
            WinnerType = game.WinnerType,
            Hero = game.Hero is not null ? new CharacterResponse
            {
                Health = game.Hero.Health,
                MaxHealth = game.Hero.MaxHealth,
                IsAlive = game.Hero.IsAlive,
                Type = "Hero"
            } : new CharacterResponse(),
            Boss = game.Boss is not null ? new CharacterResponse
            {
                Health = game.Boss.Health,
                MaxHealth = game.Boss.MaxHealth,
                IsAlive = game.Boss.IsAlive,
                Type = "Boss"
            } : new CharacterResponse(),
            CombatLog = [..game.CombatLog.Select(cl => cl.Message)]
        };
    }
}
