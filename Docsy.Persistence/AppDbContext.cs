using Docsy.Persistence.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Docsy.Persistence;

public class AppDbContext : DbContext
{
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
