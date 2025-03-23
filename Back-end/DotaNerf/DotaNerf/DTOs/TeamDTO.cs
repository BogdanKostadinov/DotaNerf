using DotaNerf.Models;

namespace DotaNerf.DTOs;

public class CreateTeamDTO
{
    public TeamName Name { get; set; }
}

public class TeamDTO
{
    public Guid Id { get; set; }
    public TeamName Name { get; set; }
    public required List<PlayerDTO> Players { get; set; }
} 