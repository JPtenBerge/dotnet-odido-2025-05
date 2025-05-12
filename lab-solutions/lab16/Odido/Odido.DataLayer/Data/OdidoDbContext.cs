using Microsoft.EntityFrameworkCore;
using Odido.DataLayer.Entities;

namespace Odido.DataLayer.Data;

public class OdidoDbContext : DbContext
{
    public OdidoDbContext(DbContextOptions<OdidoDbContext> options) : base(options)
    {
    }

    public OdidoDbContext()
    {
            
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=games.db");
        }
    }

    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<Hero> Heroes { get; set; } = null!;
    public DbSet<Boss> Bosses { get; set; } = null!;
    public DbSet<CombatLogEntry> CombatLog { get; set; } = null!;
}
