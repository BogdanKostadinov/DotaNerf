using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(g => g.WinningTeam)
                   .IsRequired();

            builder.HasOne(g => g.RadiantTeam)
                   .WithMany()
                   .HasForeignKey(g => g.RadiantTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.DireTeam)
                   .WithMany()
                   .HasForeignKey(g => g.DireTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Players)
                   .WithMany(p => p.Games)
                   .UsingEntity(j => j.ToTable("GamePlayers"));
        }
    }
}
