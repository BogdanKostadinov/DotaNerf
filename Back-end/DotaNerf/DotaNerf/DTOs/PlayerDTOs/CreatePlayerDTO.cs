namespace DotaNerf.DTOs.PlayerDTOs;

public class CreatePlayerDTO
{
    public required string Name { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
}
