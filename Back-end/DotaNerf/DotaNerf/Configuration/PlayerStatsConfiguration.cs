using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

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
               .HasForeignKey(ps => ps.PlayerId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ps => ps.HeroPlayed)
               .WithMany()
               .HasForeignKey(ps => ps.HeroId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ps => ps.Team)
               .WithMany()
               .HasForeignKey(ps => ps.TeamId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
