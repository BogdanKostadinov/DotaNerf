using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasMany(t => t.Players)
               .WithOne()
               .HasForeignKey("TeamId")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
