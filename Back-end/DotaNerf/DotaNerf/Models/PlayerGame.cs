namespace DotaNerf.Models;

public class PlayerGame
{
    public Guid GameId { get; set; }
    public Game Game { get; set; } = null!;
    public Guid PlayerId { get; set; }
    public Player Player { get; set; } = null!;
}

