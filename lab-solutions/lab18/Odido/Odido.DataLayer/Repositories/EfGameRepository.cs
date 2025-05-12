using Microsoft.EntityFrameworkCore;
using Odido.DataLayer.Data;
using Odido.DataLayer.Entities;
using Odido.DataLayer.Interfaces;

namespace Odido.DataLayer.Repositories;

public class EfGameRepository : IGameRepository
{
    private readonly OdidoDbContext _context;
    public EfGameRepository()
    {
        _context = new OdidoDbContext();
    }
    public EfGameRepository(OdidoDbContext context)
    {
        _context = context;
    }
    public async Task<List<Game>> GetActiveGamesForPlayer(string playerName)
    {
        return await _context.Games
            .Include(g => g.Characters)
            .Include(c => c.CombatLog)
            .Where(g => g.PlayerName == playerName && !g.IsCompleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Game?> GetById(int gameId)
    {
        return await _context.Games
            .Include(g => g.Characters)
            .Include(c => c.CombatLog)
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == gameId);
    }

    public async Task<Game> Create(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game> Update(Game game)
    {
        _context.Games.Update(game);
        await _context.SaveChangesAsync();
        return game;
    }
}
