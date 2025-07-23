using Docsy.Persistence.Models;
using Docsy.Persistence.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Docsy.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<Project> Project { get; set; }

    private readonly ConnectionStrings _connectionStrings;

    public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<ConnectionStrings> connectionStringsOptions) : base(options)
    {
        _connectionStrings = connectionStringsOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionStrings.DefaultConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
