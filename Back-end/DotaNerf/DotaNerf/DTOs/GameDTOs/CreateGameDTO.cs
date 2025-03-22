using DotaNerf.DTOs.PlayerStatsDTOs;
using DotaNerf.Models;

namespace DotaNerf.DTOs.GameDTOs;

public class CreateGameDTO
{
    public TeamName WinningTeam { get; set; }
    public Guid RadiantTeamId { get; set; }
    public Guid DireTeamId { get; set; }
    public List<CreatePlayerStatsDTO> PlayerStats { get; set; } = new();
}
