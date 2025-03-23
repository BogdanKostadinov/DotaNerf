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
                 .WithMany(p => p.Teams)
                 .UsingEntity(j => j.ToTable("PlayerTeams"));
    }
}
