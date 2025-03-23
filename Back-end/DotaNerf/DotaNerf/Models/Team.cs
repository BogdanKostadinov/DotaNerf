using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotaNerf.Models;

public class Team
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public TeamName Name { get; set; }

    public List<Player> Players { get; set; } = new();

    [JsonIgnore]
    public List<Game> GamesAsRadiant { get; set; } = new();
    [JsonIgnore]
    public List<Game> GamesAsDire { get; set; } = new();
}

public enum TeamName
{
    Radiant,
    Dire
}
