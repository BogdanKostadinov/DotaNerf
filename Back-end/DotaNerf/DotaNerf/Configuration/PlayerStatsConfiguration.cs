using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class PlayerStatsConfiguration : IEntityTypeConfiguration<PlayerStats>
{
    public void Configure(EntityTypeBuilder<PlayerStats> builder)
    {
        builder.HasKey(ps => ps.Id);

        builder.Property(ps => ps.Kills)
               .HasDefaultValue(0);

        builder.Property(ps => ps.Deaths)
               .HasDefaultValue(0);

        builder.Property(ps => ps.Assists)
               .HasDefaultValue(0);

        builder.HasOne(ps => ps.Player)
               .WithMany(p => p.PlayerStats)
               .HasForeignKey(ps => ps.PlayerId);

        builder.HasOne(ps => ps.Game)
               .WithMany(g => g.PlayerStats)
               .HasForeignKey(ps => ps.GameId);

        builder.HasOne(ps => ps.Team)
               .WithMany()
               .HasForeignKey(ps => ps.TeamId);
    }
}
