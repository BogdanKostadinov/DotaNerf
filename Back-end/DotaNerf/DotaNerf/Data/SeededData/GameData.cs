using DotaNerf.Models;

namespace DotaNerf.Data.SeededData;

public class GameData
{
    public static List<Game> SeedGames()
    {
        var players = PlayerData.SeedPlayers();
        var teams = TeamData.SeedTeams();

        return new List<Game>
        {
            new Game
            {
                Id = new Guid("d4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"),
                WinningTeam = TeamName.Radiant,
                RadiantTeamId = teams[0].Id,
                DireTeamId = teams[1].Id,
            },
            new Game
            {
                Id = new Guid("77f79d5e-7f7b-478a-977f-7f7b078a977f"),
                WinningTeam = TeamName.Dire,
                RadiantTeamId = teams[0].Id,
                DireTeamId = teams[1].Id,
            }
        };
    }
}
