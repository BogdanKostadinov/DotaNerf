using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotaNerf.Models;

public class PlayerDetails
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Winrate { get; set; }
    public int TotalGames { get; set; } 
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }

    // Foreign key for Player
    public Guid PlayerId { get; set; }

    // Navigation property to Player
    [JsonIgnore]
    public Player Player { get; set; } = null!;
}
