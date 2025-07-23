using Docsy.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Docsy.Persistence.EntityConfigurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasIndex(t => t.Name)
               .IsUnique();
        
        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(30);
        
        builder.HasMany(t => t.Users)
               .WithMany(u => u.Teams);

        builder.HasMany(t => t.Projects)
               .WithMany(p => p.Teams)
               .UsingEntity<Dictionary<string, object>>(
                        "ProjectTeam",
                        t => t.HasOne<Project>()
                              .WithMany()
                              .HasForeignKey("ProjectId"),
                        t => t.HasOne<Team>()
                              .WithMany()
                              .HasForeignKey("TeamId"));
    }
}
