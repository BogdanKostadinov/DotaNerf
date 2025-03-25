using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(g => g.WinningTeam)
               .IsRequired();

        builder.HasOne(g => g.RadiantTeam)
               .WithMany(t => t.GamesAsRadiant)
               .HasForeignKey(g => g.RadiantTeamId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(g => g.DireTeam)
               .WithMany(t => t.GamesAsDire)
               .HasForeignKey(g => g.DireTeamId)
               .OnDelete(DeleteBehavior.Restrict);

        //builder.HasMany(g => g.PlayerStats)
        //       .WithOne(ps => ps.Game)
        //       .HasForeignKey(ps => ps.GameId);
    }
}
