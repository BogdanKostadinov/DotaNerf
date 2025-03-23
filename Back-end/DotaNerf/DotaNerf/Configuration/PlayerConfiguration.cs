using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Winrate)
            .HasDefaultValue(0);

        // Configure the TeamId property and relationship
        builder.HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.PlayerStats)
            .WithOne(ps => ps.Player)
            .HasForeignKey(ps => ps.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Games)
            .WithMany(g => g.Players)
            .UsingEntity(j => j.ToTable("GamePlayers"));

    }
}
