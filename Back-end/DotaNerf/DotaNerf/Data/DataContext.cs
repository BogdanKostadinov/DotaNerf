using DotaNerf.Configuration;
using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}

    public DbSet<Player> Players { get; set; }
    public DbSet<GameStats> GameStats { get; set; }
    public DbSet<Hero> Heroes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new HeroConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        modelBuilder.ApplyConfiguration(new GameStatsConfiguration());

        modelBuilder.Seed();
    }
}

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var players = MockData.SeedPlayers();
        var heroes = HeroData.SeedHeroes();

        if (players is not null)
        {
            modelBuilder.Entity<Player>().HasData(players);
        }
        if (heroes is not null)
        {
            modelBuilder.Entity<Hero>().HasData(heroes);
        }
    }
}