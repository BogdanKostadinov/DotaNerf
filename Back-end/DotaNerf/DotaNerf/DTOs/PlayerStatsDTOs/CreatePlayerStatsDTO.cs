using DotaNerf.DTOs.HeroDTOs;
using DotaNerf.Models;

namespace DotaNerf.DTOs.PlayerStatsDTOs;

public class CreatePlayerStatsDTO
{
    public required HeroDTO HeroPlayed { get; set; }
    public double? Xpm { get; set; }
    public double? Gpm { get; set; }
    public int? LastHits { get; set; }
    public int? Kills { get; set; }
    public int? Deaths { get; set; }
    public int? Assists { get; set; }
    public int? GameDuration { get; set; }
    public Guid PlayerId { get; set; }
}
