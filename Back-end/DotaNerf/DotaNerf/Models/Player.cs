using System.Text.Json.Serialization;

namespace DotaNerf.Models;

public class Player
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    // Foreign key for PlayerDetails
    public Guid PlayerDetailsId { get; set; }
    public PlayerDetails PlayerDetails { get; set; } = null!;


    [JsonIgnore]
    public List<Team> Teams { get; set; } = new();
    [JsonIgnore]
    public List<PlayerStats> PlayerStats { get; set; } = new();
    [JsonIgnore]
    public List<PlayerGame> PlayerGames { get; set; } = new();
}
