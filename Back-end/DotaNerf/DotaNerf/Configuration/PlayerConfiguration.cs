using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasMany(p => p.PlayerStats)
               .WithOne(ps => ps.Player)
               .HasForeignKey(ps => ps.PlayerId);

        builder.HasMany(p => p.Games)
               .WithMany(g => g.Players)
               .UsingEntity(j => j.ToTable("PlayerGames"));
    }
}
