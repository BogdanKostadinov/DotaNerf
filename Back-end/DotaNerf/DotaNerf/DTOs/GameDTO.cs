using DotaNerf.Models;

namespace DotaNerf.DTOs;

public class GameDTO
{
    public Guid Id { get; set; }
    public TeamName WinningTeam { get; set; }
    public Guid RadiantTeamId { get; set; }
    public Guid DireTeamId { get; set; }
    public List<PlayerStatsDTO> PlayerStats { get; set; } = new();
}

public class CreateGameDTO
{
    public TeamName WinningTeam { get; set; }
    public required CreateTeamDTO RadiantTeam { get; set; } 
    public required CreateTeamDTO DireTeam { get; set; } 
    public List<CreatePlayerStatsDTO> PlayerStats { get; set; } = new();
}