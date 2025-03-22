using DotaNerf.DTOs.PlayerStatsDTOs;
using DotaNerf.Models;

namespace DotaNerf.DTOs.GameDTOs;

public class GameDTO
{
    public Guid Id { get; set; }
    public TeamName WinningTeam { get; set; }
    public Guid RadiantTeamId { get; set; }
    public Guid DireTeamId { get; set; }
    public List<PlayerStatsDTO> PlayerStats { get; set; } = new();
}
