using DotaNerf.DTOs.PlayerStatsDTOs;
using DotaNerf.Models;

namespace DotaNerf.DTOs.PlayerDTOs;

public class PlayerDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
    public int TotalGames { get; set; }
    public double WinRate { get; set; }
    public List<PlayerStatsDTO> Games { get; set; } = new();
    public List<PlayerStats> PlayerStats { get; set; } = new();
}
