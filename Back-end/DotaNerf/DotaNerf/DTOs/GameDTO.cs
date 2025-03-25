using DotaNerf.Models;

namespace DotaNerf.DTOs;

public class GameDTO
{
    public Guid Id { get; set; }
    public TeamName WinningTeam { get; set; }
    public required TeamDTO RadiantTeam { get; set; }
    public required TeamDTO DireTeam { get; set; }
}

public class CreateGameDTO
{
    public TeamName WinningTeam { get; set; }
    public required CreateTeamDTO RadiantTeam { get; set; } 
    public required CreateTeamDTO DireTeam { get; set; } 
}