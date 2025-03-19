namespace DotaNerf.DTOs;

public class PlayerDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
    public int TotalGames { get; set; }
    public double WinRate { get; set; }
    public List<GameStatsDTO> Games { get; set; } = new();
}
