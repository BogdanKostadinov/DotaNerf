namespace DotaNerf.DTOs;

public class PlayerStatsDTO
{
    public Guid Id { get; set; }
    public required HeroDTO HeroPlayed { get; set; }
    public int? Kills { get; set; }
    public int? Deaths { get; set; }
    public int? Assists { get; set; }
    public Guid PlayerId { get; set; }
    public Guid GameId { get; set; }
    public Guid TeamId { get; set; }
}

public class CreatePlayerStatsDTO
{
    public required CreateHeroDTO HeroPlayed { get; set; } 
    public int? Kills { get; set; }
    public int? Deaths { get; set; }
    public int? Assists { get; set; }
}

