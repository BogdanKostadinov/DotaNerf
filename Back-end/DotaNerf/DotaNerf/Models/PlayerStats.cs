using System.Text.Json.Serialization;

namespace DotaNerf.Models;

public class PlayerStats
{
    public Guid Id { get; set; }
    public Hero? HeroPlayed { get; set; }
    public int? Kills { get; set; }  
    public int? Deaths { get; set; } 
    public int? Assists { get; set; }  

    [JsonIgnore]
    public Game? Game { get; set; }
    [JsonIgnore]
    public Player? Player { get; set; }
    [JsonIgnore]
    public Team? Team { get; set; }

    public Guid? PlayerId { get; set; }
    public Guid? GameId { get; set; }
    public Guid? TeamId { get; set; }

    public int HeroId { get; set; } // Foreign key reference to Hero
}