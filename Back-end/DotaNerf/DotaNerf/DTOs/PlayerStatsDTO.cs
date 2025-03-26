namespace DotaNerf.DTOs;

public class PlayerStatsDTO
{
    public Guid Id { get; set; }
    public required HeroDTO HeroPlayed { get; set; }
    public int? Kills { get; set; }
    public int? Deaths { get; set; }
    public int? Assists { get; set; }
}

public class CreatePlayerStatsDTO
{
    public required int HeroPlayedId { get; set; } 
    public int? Kills { get; set; }
    public int? Deaths { get; set; }
    public int? Assists { get; set; }
}

