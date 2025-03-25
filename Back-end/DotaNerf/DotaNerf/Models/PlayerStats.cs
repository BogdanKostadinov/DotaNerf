using System.Text.Json.Serialization;

namespace DotaNerf.Models;

public class PlayerStats
{
    public Guid Id { get; set; }
    public Hero? HeroPlayed { get; set; }
    public required int HeroPlayedId { get; set; }
    public int? Kills { get; set; }  
    public int? Deaths { get; set; } 
    public int? Assists { get; set; }  

    // Foreign keys
    public Guid PlayerId { get; set; }
    public Guid GameId { get; set; }
    public Guid TeamId { get; set; }

    // Navigation properties
    [JsonIgnore]
    public Game Game { get; set; } = null!;
    [JsonIgnore]
    public Player Player { get; set; } = null!;
    [JsonIgnore]
    public Team Team { get; set; } = null!;
}