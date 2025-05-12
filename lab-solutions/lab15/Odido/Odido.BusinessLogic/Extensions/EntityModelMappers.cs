namespace Odido.BusinessLogic.Extensions;

public static class EntityModelMappers
{
    //From Models.Game to Entities.Game
    public static DataLayer.Entities.Game ToEntity(this Models.Game game)
    {
        return new DataLayer.Entities.Game
        {
            Id = game.Id,
            PlayerName = game.PlayerName,
            CreationDate = game.CreationDate,
            IsCompleted = game.IsCompleted,
            WinnerType = game.WinnerType,
            Characters = [..game.Characters.Select(c => c.ToEntity())],
            CombatLog = [..game.CombatLog.Select(c => c.ToEntity())]
        };
    }
    public static DataLayer.Entities.Character ToEntity(this Models.Character character)
    {
        return character switch
        {
            Models.Hero hero => new DataLayer.Entities.Hero
            {
                Id = hero.Id,
                GameId = hero.GameId,
                Name = hero.Name,
                Health = hero.Health,
                MaxHealth = hero.MaxHealth,
            },
            Models.Boss boss => new DataLayer.Entities.Boss
            {
                Id = boss.Id,
                GameId = boss.GameId,
                Name = boss.Name,
                Health = boss.Health,
                Level = boss.Level,
                MaxHealth = boss.MaxHealth,
            },
            _ => throw new ArgumentException("Unknown character type")
        };
    }

    public static DataLayer.Entities.CombatLogEntry ToEntity(this Models.CombatLogEntry entry)
    {
        return new DataLayer.Entities.CombatLogEntry
        {
            Id = entry.Id,
            GameId = entry.GameId,
            Message = entry.Message,
            Timestamp = entry.Timestamp
        };
    }


    public static Models.Game ToModel(this DataLayer.Entities.Game entity)
    {
        return new Models.Game(
            entity.Id, 
            entity.PlayerName, 
            entity.CreationDate, 
            entity.IsCompleted,
            entity.WinnerType,
            [..entity.Characters.Select(c => c.ToModel())],
            [..entity.CombatLog.Select(c => c.ToModel())]
        );
        
    }

    public static Models.Character ToModel(this DataLayer.Entities.Character entity)
    {
        return entity switch
        {
            DataLayer.Entities.Hero hero => new Models.Hero(hero.Id,hero.GameId, hero.Name, hero.Health,"Hero"),
            DataLayer.Entities.Boss boss => new Models.Boss(boss.Id, boss.GameId, boss.Name, boss.Health, "Boss", boss.Level),
            _ => throw new ArgumentException("Unknown character type")
        };
    }

    public static Models.CombatLogEntry ToModel(this DataLayer.Entities.CombatLogEntry entry)
    {
        return new Models.CombatLogEntry(entry.Id, entry.GameId, entry.Message, entry.Timestamp);
    }
}
