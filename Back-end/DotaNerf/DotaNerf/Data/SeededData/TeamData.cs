using DotaNerf.Models;

namespace DotaNerf.Data.SeededData;

public class TeamData
{
    public static List<Team> SeedTeams()
    {
        return new List<Team>
        {
            new Team { Id = new Guid("a4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), Name = TeamName.Radiant },
            new Team { Id = new Guid("b4f49d5e-4f4b-4d8a-9e4f-4f4b7d8a9e4f"), Name = TeamName.Dire },
            new Team { Id = new Guid("b642cc17-3c5b-4ad7-8830-9c9bb2107750"), Name = TeamName.Radiant },
            new Team { Id = new Guid("b5f11c36-5e5d-471e-9537-0d1f8765c15c"), Name = TeamName.Dire }
        };
    }
}
