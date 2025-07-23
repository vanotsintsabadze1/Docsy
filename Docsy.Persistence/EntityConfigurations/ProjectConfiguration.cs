using Docsy.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Docsy.Persistence.EntityConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Name)
               .IsUnique();

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasMany(p => p.Teams)
               .WithMany(t => t.Projects);
    }
}
