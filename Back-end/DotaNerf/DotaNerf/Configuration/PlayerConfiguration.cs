using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasMany(e => e.Games)
            .WithOne(e => e.Player)
            .HasForeignKey(e => e.PlayerId);
    }
}
