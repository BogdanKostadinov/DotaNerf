namespace DotaNerf.Models;

public class GameStats
{
        public int Id { get; set; }
        public string HeroPlayed { get; set; }
        public double? Xpm { get; set; }  // Nullable double for optional properties
        public double? Gpm { get; set; }  // Nullable double for optional properties
        public int? LastHits { get; set; }  // Nullable int for optional properties
        public int? Kills { get; set; }  // Nullable int for optional properties
        public int? Deaths { get; set; }  // Nullable int for optional properties
        public int? Assists { get; set; }  // Nullable int for optional properties
        public int? GameDuration { get; set; }  // Nullable int for optional properties
        public GameResult GameResult { get; set; }
}

public enum GameResult
{
    Win,
    Loss
}
