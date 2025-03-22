using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class PlayerStatsConfiguration : IEntityTypeConfiguration<PlayerStats>
{
    public void Configure(EntityTypeBuilder<PlayerStats> builder)
    {
        builder.HasKey(ps => ps.Id);

        builder.HasOne(ps => ps.Player)
               .WithMany(p => p.PlayerStats)
               .HasForeignKey(ps => ps.PlayerId);

        builder.HasOne(ps => ps.Game)
               .WithMany(g => g.PlayerStats)
               .HasForeignKey(ps => ps.GameId);
    }
}
