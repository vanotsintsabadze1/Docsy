using Docsy.Persistence.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Docsy.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>();
        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        return services;
    }
}