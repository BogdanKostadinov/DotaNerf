using DotaNerf.Models;

namespace DotaNerf.DTOs;

public class TeamDTO
{
    public Guid Id { get; set; }
    public TeamName Name { get; set; }
    public List<PlayerDTO> Players { get; set; } = new();
}
public class CreateTeamDTO
{
    public TeamName Name { get; set; }
    public List<CreatePlayerDTO> Players { get; set; } = new();
}
