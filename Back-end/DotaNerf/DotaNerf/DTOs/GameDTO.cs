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
    public required TeamName WinningTeam { get; set; }
    public required TeamDTO RadiantTeam { get; set; }
    public required TeamDTO DireTeam { get; set; }
}