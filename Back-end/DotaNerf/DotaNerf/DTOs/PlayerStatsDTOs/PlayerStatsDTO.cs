using DotaNerf.Models;

namespace DotaNerf.DTOs.PlayerStatsDTOs;

public class PlayerStatsDTO
{
    public Guid Id { get; set; }
    public required Hero HeroPlayed { get; set; }
    public double? Xpm { get; set; }
    public double? Gpm { get; set; }
    public int? LastHits { get; set; }
    public int? Kills { get; set; }
    public int? Deaths { get; set; }
    public int? Assists { get; set; }
    public Guid PlayerId { get; set; }
    public Guid GameId { get; set; }
}
