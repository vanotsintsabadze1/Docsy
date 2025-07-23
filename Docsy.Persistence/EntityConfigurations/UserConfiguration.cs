using Docsy.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Docsy.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Username)
               .IsUnique();

        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.HasMany(u => u.Roles)
               .WithMany()
               .UsingEntity<Dictionary<string, object>>(
                       "UserRole", 
                       u => u.HasOne<Role>()
                             .WithMany()
                             .HasForeignKey("RoleId"),
                       u => u.HasOne<User>()
                             .WithMany()
                             .HasForeignKey("UserId"));

        builder.HasMany(u => u.Teams)
               .WithMany(u => u.Users)
               .UsingEntity<Dictionary<string, object>>(
                       "TeamUser",
                       u => u.HasOne<Team>()
                             .WithMany()
                             .HasForeignKey("TeamId"),
                       u => u.HasOne<User>()
                             .WithMany()
                             .HasForeignKey("UserId"));
    }
}