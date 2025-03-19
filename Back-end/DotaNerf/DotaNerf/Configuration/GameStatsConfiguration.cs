using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration
{
    public class GameStatsConfiguration : IEntityTypeConfiguration<GameStats>
    {
        public void Configure(EntityTypeBuilder<GameStats> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(e => e.Player)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.PlayerId)
                .OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
