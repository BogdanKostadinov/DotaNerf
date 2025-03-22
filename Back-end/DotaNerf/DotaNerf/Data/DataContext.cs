using DotaNerf.Configuration;
using DotaNerf.Data.SeededData;
using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}

    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerStats> GameStats { get; set; }
    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Game> Games { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerStatsConfiguration());

        modelBuilder.Seed();
    }
}

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var players = PlayerData.SeedPlayers();
        var teams = TeamData.SeedTeams();
        var heroes = HeroData.SeedHeroes();
        var games = GameData.SeedGames();

        if (players is not null)
        {
            modelBuilder.Entity<Player>().HasData(players);
        }
        if (teams is not null)
        {
            modelBuilder.Entity<Team>().HasData(teams);
        }
        if (heroes is not null)
        {
            modelBuilder.Entity<Hero>().HasData(heroes);
        }
        if (games is not null)
        {
            modelBuilder.Entity<Game>().HasData(games);
        }
    }
}