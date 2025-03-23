namespace DotaNerf.DTOs;

public class PlayerDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required List<PlayerStatsDTO> PlayerStats { get; set; }
}

public class CreatePlayerDTO
{
    public required string Name { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
}

