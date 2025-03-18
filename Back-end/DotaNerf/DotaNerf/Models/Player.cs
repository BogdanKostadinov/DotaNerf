namespace DotaNerf.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Winrate { get; set; }
    public int TotalGames { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
    public List<GameStats> Games { get; set; }

    public Player()
    {
        Games = new List<GameStats>();
    }
}
