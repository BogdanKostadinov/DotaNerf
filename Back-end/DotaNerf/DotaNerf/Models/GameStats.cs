using System.Text.Json.Serialization;

namespace DotaNerf.Models;

public class GameStats
{
    public Guid Id { get; set; }
    public required string HeroPlayed { get; set; }
    public double? Xpm { get; set; }  
    public double? Gpm { get; set; }  
    public int? LastHits { get; set; }  
    public int? Kills { get; set; }  
    public int? Deaths { get; set; } 
    public int? Assists { get; set; }  
    public int? GameDuration { get; set; }  
    public GameResult GameResult { get; set; }
    public Guid PlayerId { get; set; }
    [JsonIgnore]
    public Player? Player { get; set; }
}

public enum GameResult
{
    Win,
    Loss
}
