using System.Text.Json.Serialization;

namespace DotaNerf.Models;

public class PlayerStats
{
    public Guid Id { get; set; }
    public required Hero HeroPlayed { get; set; }
    public double? Xpm { get; set; }  
    public double? Gpm { get; set; }  
    public int? LastHits { get; set; }  
    public int? Kills { get; set; }  
    public int? Deaths { get; set; } 
    public int? Assists { get; set; }  

    [JsonIgnore]
    public Game? Game { get; set; }
    [JsonIgnore]
    public Player? Player { get; set; }

    public Guid PlayerId { get; set; }
    public Guid GameId { get; set; }
}