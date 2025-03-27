namespace DotaNerf.DTOs;

public class PlayerDetailsDTO
{
    public Guid Id { get; set; }
    public int TotalGames { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
}

public class CreatePlayerDetailsDTO
{
    public int TotalGames { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
}

