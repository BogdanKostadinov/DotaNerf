using DotaNerf.Models;

namespace DotaNerf.Data;

public class MockData
{
    public static List<Player> SeedPlayers()
    {
        return new List<Player>
        {
            new Player { Id = new Guid("a1e29d5e-1c4b-4b8a-9b1e-1c4b4b8a9b1e"), Name = "dummy", Winrate = 67, TotalGames = 9, GamesWon = 6, GamesLost = 3 },
            new Player { Id = new Guid("b2f29d5e-2d4b-4c8a-9c2e-2d4b5c8a9c2e"), Name = "Stoqn (kolega)", Winrate = 67, TotalGames = 9, GamesWon = 6, GamesLost = 3 },
            new Player { Id = new Guid("c3f39d5e-3e4b-4c8a-9d3e-3e4b6c8a9d3e"), Name = "Veni", Winrate = 63, TotalGames = 19, GamesWon = 12, GamesLost = 7 },
            new Player { Id = new Guid("d4f49d5e-4f4b-4c8a-9e4e-4f4b7c8a9e4e"), Name = "Kriskata", Winrate = 60, TotalGames = 15, GamesWon = 9, GamesLost = 6 },
            new Player { Id = new Guid("e5f59d5e-5f4b-4c8a-9f5e-5f4b8c8a9f5e"), Name = "Marto", Winrate = 59, TotalGames = 17, GamesWon = 10, GamesLost = 7 },
            new Player { Id = new Guid("f6f69d5e-6f4b-4c8a-9f6e-6f4b9c8a9f6e"), Name = "Steli", Winrate = 50, TotalGames = 14, GamesWon = 7, GamesLost = 7 },
            new Player { Id = new Guid("07f79d5e-7f4b-4c8a-9f7e-7f4b0c8a9f7e"), Name = "Rumen", Winrate = 52, TotalGames = 19, GamesWon = 10, GamesLost = 9 },
            new Player { Id = new Guid("18f89d5e-8f4b-4c8a-9f8e-8f4b1c8a9f8e"), Name = "Bobur Kurva", Winrate = 40, TotalGames = 15, GamesWon = 6, GamesLost = 9 },
            new Player { Id = new Guid("29f99d5e-9f4b-4c8a-9f9e-9f4b2c8a9f9e"), Name = "Dj Misho", Winrate = 38, TotalGames = 16, GamesWon = 6, GamesLost = 10 },
            new Player { Id = new Guid("30f09d5e-0f4b-4c8a-9f0e-0f4b3c8a9f0e"), Name = "Kuncho", Winrate = 37, TotalGames = 19, GamesWon = 7, GamesLost = 12 },
            new Player { Id = new Guid("41f19d5e-1f4b-4c8a-9f1e-1f4b4c8a9f1e"), Name = "Sofiqneca", Winrate = 20, TotalGames = 5, GamesWon = 1, GamesLost = 4 },
            new Player { Id = new Guid("52f29d5e-2f4b-4c8a-9f2e-2f4b5c8a9f2e"), Name = "Vaneto", Winrate = 25, TotalGames = 8, GamesWon = 2, GamesLost = 6 },
            new Player { Id = new Guid("63f39d5e-3f4b-4c8a-9f3e-3f4b6c8a9f3e"), Name = "Mario", Winrate = 0, TotalGames = 6, GamesWon = 0, GamesLost = 6 }
        };
    }
}
