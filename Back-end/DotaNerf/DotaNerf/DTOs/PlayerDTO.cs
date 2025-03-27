namespace DotaNerf.DTOs;

public class PlayerDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required PlayerDetailsDTO PlayerDetails { get; set; }
    public List<PlayerStatsDTO> PlayerStats { get; set; } = new();
}

public class CreatePlayerDTO
{
    public Guid Id { get; set; }
    public required CreatePlayerStatsDTO PlayerStats { get; set; }
}

