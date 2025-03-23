using DotaNerf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaNerf.Configuration;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.Property(t => t.Name)
               .IsRequired();
        
        builder.HasMany(t => t.Players)
               .WithOne(p => p.Team)
               .HasForeignKey(p => p.TeamId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
