using DotaNerf.Configuration;
using DotaNerf.Data.SeededData;
using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerStats> PlayerStats { get; set; }
    public DbSet<PlayerGame> PlayerGames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new HeroConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerStatsConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerGameConfiguration());

        modelBuilder.Seed();
    }
}

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Seed Heroes
        modelBuilder.Entity<Hero>().HasData(MockData.SeedHeroes());

        // Seed Teams
        modelBuilder.Entity<Team>().HasData(MockData.SeedTeams());

        // Seed Players
        modelBuilder.Entity<Player>().HasData(MockData.SeedPlayers());

        // Seed Games
        modelBuilder.Entity<Game>().HasData(MockData.SeedGames());

        // Seed PlayerStats
        modelBuilder.Entity<PlayerStats>().HasData(MockData.SeedPlayerStats());
    }
}