namespace DotaNerf.Models;

public class Player
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public double Winrate { get; set; }
    public int TotalGames { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }

    public List<Team> Teams { get; set; } = new();
    public List<PlayerStats> PlayerStats { get; set; } = new();
}
