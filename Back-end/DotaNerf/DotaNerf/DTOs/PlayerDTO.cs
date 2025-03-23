namespace DotaNerf.DTOs;

public class PlayerDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public double Winrate { get; set; }
    public int TotalGames { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
    public List<TeamDTO> Teams { get; set; } = new();
    public List<PlayerStatsDTO> PlayerStats { get; set; } = new();
}

public class CreatePlayerDTO
{
    public required string Name { get; set; }
    public List<Guid> PlayerStatsIds { get; set; } = new();
    public List<Guid> GameIds { get; set; } = new();
    public List<Guid> PlayerInTeamIds { get; set; } = new();
}

