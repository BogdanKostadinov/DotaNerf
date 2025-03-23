using System.ComponentModel.DataAnnotations;

namespace DotaNerf.Models;

public class Game
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public required TeamName WinningTeam { get; set; }

    public Guid RadiantTeamId { get; set; }
    public Guid DireTeamId { get; set; }
    public Team? RadiantTeam { get; set; }
    public Team? DireTeam { get; set; }

    public List<Player> Players { get; set; } = new();

}
