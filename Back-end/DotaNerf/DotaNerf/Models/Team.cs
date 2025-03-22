using System.ComponentModel.DataAnnotations;

namespace DotaNerf.Models;

public class Team
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public TeamName Name { get; set; }
    public List<Player> Players { get; set; } = new List<Player>();
}

public enum TeamName
{
    Radiant,
    Dire
}
