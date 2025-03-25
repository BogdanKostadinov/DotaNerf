using DotaNerf.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Configuration;

public class PlayerGameConfiguration : IEntityTypeConfiguration<PlayerGame>
{
    public void Configure(EntityTypeBuilder<PlayerGame> builder)
    {
        builder.HasKey(gp => new { gp.GameId, gp.PlayerId });

        builder.HasOne(gp => gp.Game)
               .WithMany(g => g.PlayerGames)
               .HasForeignKey(gp => gp.GameId);

        builder.HasOne(gp => gp.Player)
               .WithMany(p => p.PlayerGames)
               .HasForeignKey(gp => gp.PlayerId);
    }
}
