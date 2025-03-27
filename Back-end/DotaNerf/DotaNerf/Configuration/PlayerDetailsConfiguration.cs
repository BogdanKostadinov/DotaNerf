using DotaNerf.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Configuration;

public class PlayerDetailsConfiguration : IEntityTypeConfiguration<PlayerDetails>
{
    public void Configure(EntityTypeBuilder<PlayerDetails> builder)
    {
        builder.HasKey(pd => pd.Id);

        builder.Property(pd => pd.TotalGames)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(pd => pd.GamesWon)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(pd => pd.GamesLost)
               .IsRequired()
               .HasDefaultValue(0);

        builder.HasOne(pd => pd.Player)
               .WithOne(p => p.PlayerDetails)
               .HasForeignKey<PlayerDetails>(pd => pd.PlayerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
