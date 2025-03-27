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

        builder.HasOne(p => p.PlayerDetails)
               .WithOne(pd => pd.Player)
               .HasForeignKey<PlayerDetails>(pd => pd.PlayerId);

        builder.HasMany(p => p.PlayerStats)
               .WithOne(ps => ps.Player)
               .HasForeignKey(ps => ps.PlayerId);

        builder.HasMany(p => p.Teams)
               .WithMany(t => t.Players)
               .UsingEntity(j => j.ToTable("PlayerTeams"));
    }
}
