using DotaNerf.Models;

namespace DotaNerf.Data.SeededData;

public class PlayerStatsData
{
    public static List<PlayerStats> SeedPlayerStats()
    {
        var heroes = HeroData.SeedHeroes();
        var players = PlayerData.SeedPlayers();
        var games = GameData.SeedGames();

        return new List<PlayerStats>
        {
            new PlayerStats
            {
                Id = new Guid("e5f59d5e-5f5b-4e8a-9f5f-5f5b8e8a9f5f"),
                HeroPlayed = heroes[2], 
                Xpm = 600,
                Gpm = 550,
                LastHits = 300,
                Kills = 15,
                Deaths = 5,
                Assists = 10,
                PlayerId = players[0].Id,
                GameId = games[0].Id
            },
            new PlayerStats
            {
                Id = new Guid("f6f69d5e-6f6b-4f8a-9f6f-6f6b9f8a9f6f"),
                HeroPlayed = heroes[5],
                Xpm = 400,
                Gpm = 350,
                LastHits = 100,
                Kills = 5,
                Deaths = 10,
                Assists = 15,
                PlayerId = players[1].Id, 
                GameId = games[0].Id 
            }
        };
    }

}
