using DotaNerf.Models;

namespace DotaNerf.DTOs;

public class CreateTeamDTO
{
    public TeamName Name { get; set; }
    public List<Guid> PlayerIds { get; set; } = new();
}

public class TeamDTO
{
    public Guid Id { get; set; }
    public TeamName Name { get; set; }
    public List<GameDTO> GamesAsRadiant { get; set; } = new();
    public List<GameDTO> GamesAsDire { get; set; } = new();
    public List<PlayerDTO> Players { get; set; } = new();
} 