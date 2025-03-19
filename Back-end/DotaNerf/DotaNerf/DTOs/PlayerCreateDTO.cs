namespace DotaNerf.DTOs;

public class PlayerCreateDTO
{
    public required string Name { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
}
