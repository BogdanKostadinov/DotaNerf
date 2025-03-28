using DotaNerf.Models;

namespace DotaNerf.Data.SeededData;

public static class MockData
{
    // Define GUIDs for players, teams, and games
    public static readonly Guid DummyPlayerId = new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e");
    public static readonly Guid VeniPlayerId = new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e");

    public static readonly Guid RadiantTeamId = new Guid("d4f49d5e-4f4b-4d8a-9e4e-4f4b7d8a9e4e");
    public static readonly Guid DireTeamId = new Guid("e5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e");

    public static readonly Guid Game1Id = new Guid("f6f69d5e-6f6b-4f8a-9f6e-6f6b9f8a9f6e");
    public static readonly Guid Game2Id = new Guid("b5f59d5e-5f5b-4e8a-9f5e-5f5b8e8a9f5e");

    public static List<Hero> SeedHeroes()
    {
        return new List<Hero>
        {
            new Hero { Id = 1, Name = "Abaddon" },
            new Hero { Id = 2, Name = "Alchemist" },
            new Hero { Id = 3, Name = "Ancient Apparition" },
            new Hero { Id = 4, Name = "Anti-Mage" },
            new Hero { Id = 5, Name = "Arc Warden" },
            new Hero { Id = 6, Name = "Axe" },
            new Hero { Id = 7, Name = "Bane" },
            new Hero { Id = 8, Name = "Batrider" },
            new Hero { Id = 9, Name = "Beastmaster" },
            new Hero { Id = 10, Name = "Bloodseeker" },
            new Hero { Id = 11, Name = "Bounty Hunter" },
            new Hero { Id = 12, Name = "Brewmaster" },
            new Hero { Id = 13, Name = "Bristleback" },
            new Hero { Id = 14, Name = "Broodmother" },
            new Hero { Id = 15, Name = "Centaur Warrunner" },
            new Hero { Id = 16, Name = "Chaos Knight" },
            new Hero { Id = 17, Name = "Chen" },
            new Hero { Id = 18, Name = "Clinkz" },
            new Hero { Id = 19, Name = "Clockwerk" },
            new Hero { Id = 20, Name = "Crystal Maiden" },
            new Hero { Id = 21, Name = "Dark Seer" },
            new Hero { Id = 22, Name = "Dark Willow" },
            new Hero { Id = 23, Name = "Dawnbreaker" },
            new Hero { Id = 24, Name = "Dazzle" },
            new Hero { Id = 25, Name = "Death Prophet" },
            new Hero { Id = 26, Name = "Disruptor" },
            new Hero { Id = 27, Name = "Doom" },
            new Hero { Id = 28, Name = "Dragon Knight" },
            new Hero { Id = 29, Name = "Drow Ranger" },
            new Hero { Id = 30, Name = "Earth Spirit" },
            new Hero { Id = 31, Name = "Earthshaker" },
            new Hero { Id = 32, Name = "Elder Titan" },
            new Hero { Id = 33, Name = "Ember Spirit" },
            new Hero { Id = 34, Name = "Enchantress" },
            new Hero { Id = 35, Name = "Enigma" },
            new Hero { Id = 36, Name = "Faceless Void" },
            new Hero { Id = 37, Name = "Grimstroke" },
            new Hero { Id = 38, Name = "Gyrocopter" },
            new Hero { Id = 39, Name = "Hoodwink" },
            new Hero { Id = 40, Name = "Huskar" },
            new Hero { Id = 41, Name = "Invoker" },
            new Hero { Id = 42, Name = "Io" },
            new Hero { Id = 43, Name = "Jakiro" },
            new Hero { Id = 44, Name = "Juggernaut" },
            new Hero { Id = 45, Name = "Keeper of the Light" },
            new Hero { Id = 46, Name = "Kunkka" },
            new Hero { Id = 121, Name = "Kez" },
            new Hero { Id = 47, Name = "Legion Commander" },
            new Hero { Id = 48, Name = "Leshrac" },
            new Hero { Id = 49, Name = "Lich" },
            new Hero { Id = 50, Name = "Lifestealer" },
            new Hero { Id = 51, Name = "Lina" },
            new Hero { Id = 52, Name = "Lion" },
            new Hero { Id = 53, Name = "Lone Druid" },
            new Hero { Id = 54, Name = "Luna" },
            new Hero { Id = 55, Name = "Lycan" },
            new Hero { Id = 56, Name = "Magnus" },
            new Hero { Id = 57, Name = "Marci" },
            new Hero { Id = 58, Name = "Mars" },
            new Hero { Id = 59, Name = "Medusa" },
            new Hero { Id = 60, Name = "Meepo" },
            new Hero { Id = 61, Name = "Mirana" },
            new Hero { Id = 62, Name = "Monkey King" },
            new Hero { Id = 63, Name = "Morphling" },
            new Hero { Id = 64, Name = "Muerta" },
            new Hero { Id = 65, Name = "Naga Siren" },
            new Hero { Id = 66, Name = "Nature's Prophet" },
            new Hero { Id = 67, Name = "Necrophos" },
            new Hero { Id = 68, Name = "Night Stalker" },
            new Hero { Id = 69, Name = "Nyx Assassin" },
            new Hero { Id = 70, Name = "Ogre Magi" },
            new Hero { Id = 71, Name = "Omniknight" },
            new Hero { Id = 72, Name = "Oracle" },
            new Hero { Id = 73, Name = "Outworld Destroyer" },
            new Hero { Id = 74, Name = "Pangolier" },
            new Hero { Id = 75, Name = "Phantom Assassin" },
            new Hero { Id = 76, Name = "Phantom Lancer" },
            new Hero { Id = 77, Name = "Phoenix" },
            new Hero { Id = 78, Name = "Primal Beast" },
            new Hero { Id = 79, Name = "Puck" },
            new Hero { Id = 80, Name = "Pudge" },
            new Hero { Id = 81, Name = "Pugna" },
            new Hero { Id = 82, Name = "Queen of Pain" },
            new Hero { Id = 83, Name = "Razor" },
            new Hero { Id = 84, Name = "Riki" },
            new Hero { Id = 85, Name = "Rubick" },
            new Hero { Id = 120, Name = "Ringmaster" },
            new Hero { Id = 86, Name = "Sand King" },
            new Hero { Id = 87, Name = "Shadow Demon" },
            new Hero { Id = 88, Name = "Shadow Fiend" },
            new Hero { Id = 89, Name = "Shadow Shaman" },
            new Hero { Id = 90, Name = "Silencer" },
            new Hero { Id = 91, Name = "Skywrath Mage" },
            new Hero { Id = 92, Name = "Slardar" },
            new Hero { Id = 93, Name = "Slark" },
            new Hero { Id = 94, Name = "Snapfire" },
            new Hero { Id = 95, Name = "Sniper" },
            new Hero { Id = 96, Name = "Spectre" },
            new Hero { Id = 97, Name = "Spirit Breaker" },
            new Hero { Id = 98, Name = "Storm Spirit" },
            new Hero { Id = 99, Name = "Sven" },
            new Hero { Id = 100, Name = "Techies" },
            new Hero { Id = 101, Name = "Templar Assassin" },
            new Hero { Id = 102, Name = "Terrorblade" },
            new Hero { Id = 103, Name = "Tidehunter" },
            new Hero { Id = 104, Name = "Timbersaw" },
            new Hero { Id = 105, Name = "Tinker" },
            new Hero { Id = 106, Name = "Tiny" },
            new Hero { Id = 107, Name = "Treant Protector" },
            new Hero { Id = 108, Name = "Troll Warlord" },
            new Hero { Id = 109, Name = "Tusk" },
            new Hero { Id = 110, Name = "Underlord" },
            new Hero { Id = 111, Name = "Undying" },
            new Hero { Id = 112, Name = "Ursa" },
            new Hero { Id = 113, Name = "Vengeful Spirit" },
            new Hero { Id = 114, Name = "Venomancer" },
            new Hero { Id = 115, Name = "Viper" },
            new Hero { Id = 116, Name = "Void Spirit" },
            new Hero { Id = 117, Name = "Warlock" },
            new Hero { Id = 118, Name = "Wraith King" },
            new Hero { Id = 119, Name = "Zeus" }
        };

    }

    public static List<Player> SeedPlayers()
    {
        return new List<Player>
        {
            new Player
            {
                Id = DummyPlayerId,
                Name = "dummy",
                PlayerDetailsId = new Guid("d5f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e")
            },
            new Player
            {
                Id = VeniPlayerId,
                Name = "Veni",
                PlayerDetailsId = new Guid("e6f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e")
            }
            //new Player { Id = new Guid("d4f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"), Name = "Kriskata", Winrate = 60, TotalGames = 15, GamesWon = 9, GamesLost = 6 },
            //new Player { Id = new Guid("e5f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), Name = "Marto", Winrate = 59, TotalGames = 17, GamesWon = 10, GamesLost = 7 },
            //new Player { Id = new Guid("f6f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"), Name = "Steli", Winrate = 50, TotalGames = 14, GamesWon = 7, GamesLost = 7 },
            //new Player { Id = new Guid("07f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"), Name = "Rumen", Winrate = 52, TotalGames = 19, GamesWon = 10, GamesLost = 9 },
            //new Player { Id = new Guid("18f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"), Name = "Bobur Kurva", Winrate = 40, TotalGames = 15, GamesWon = 6, GamesLost = 9 },
            //new Player { Id = new Guid("29f99d5e-9f4b-4c8a-9f9e-9f4b2c8a9f9e"), Name = "Dj Misho", Winrate = 38, TotalGames = 16, GamesWon = 6, GamesLost = 10 },
            //new Player { Id = new Guid("30f09d5e-0f4b-4c8a-9f0e-0f4b3c8a9f0e"), Name = "Kuncho", Winrate = 37, TotalGames = 19, GamesWon = 7, GamesLost = 12 },
            //new Player { Id = new Guid("41f19d5e-1f4b-4c8a-9f1e-1f4b4c8a9f1e"), Name = "Sofiqneca", Winrate = 20, TotalGames = 5, GamesWon = 1, GamesLost = 4 },
            //new Player { Id = new Guid("52f29d5e-2f4b-4c8a-9f2e-2f4b5c8a9f2e"), Name = "Vaneto", Winrate = 25, TotalGames = 8, GamesWon = 2, GamesLost = 6 },
            //new Player { Id = new Guid("63f39d5e-3f4b-4c8a-9f3e-3f4b6c8a9f3e"), Name = "Mario", Winrate = 0, TotalGames = 6, GamesWon = 0, GamesLost = 6 }
        };
    }

    public static List<PlayerDetails> SeedPlayerDetails()
    {
        return new List<PlayerDetails>
        {
            new PlayerDetails
            {
                Id = new Guid("d5f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"),
                PlayerId = DummyPlayerId,
                Winrate = 60,
                TotalGames = 15,
                GamesWon = 9,
                GamesLost = 6
            },
            new PlayerDetails
            {
                Id = new Guid("e6f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"),
                PlayerId = VeniPlayerId,
                Winrate = 59,
                TotalGames = 17,
                GamesWon = 10,
                GamesLost = 7
            }
        };
    }

    public static List<Game> SeedGames()
    {
        return new List<Game>
        {
            new Game
            {
                Id = Game1Id,
                WinningTeam = TeamName.Radiant,
                RadiantTeamId = RadiantTeamId,
                DireTeamId = DireTeamId,
            }
        };
    }

    public static List<Team> SeedTeams()
    {
        return new List<Team>
        {
            new Team
            {
                Id = RadiantTeamId,
                Name = TeamName.Radiant
            },
            new Team
            {
                Id = DireTeamId,
                Name = TeamName.Dire
            }
        };
    }

    public static List<PlayerStats> SeedPlayerStats()
    {
        return new List<PlayerStats>
        {
            new PlayerStats
            {
                Id = new Guid("88889d5e-888b-488a-988e-888b188a988e"),
                HeroPlayedId = 1,
                Kills = 5,
                Deaths = 3,
                Assists = 10,
                PlayerId = DummyPlayerId,
                GameId = Game1Id,
                TeamId = RadiantTeamId,
            },
            new PlayerStats
            {
                Id = new Guid("99999d5e-999b-499a-999e-999b399a999e"),
                HeroPlayedId = 3,
                Kills = 12,
                Deaths = 4,
                Assists = 8,
                PlayerId = VeniPlayerId,
                GameId = Game1Id,
                TeamId = DireTeamId,
            },
        };
    }
}
