using Docsy.API.Constants.Options;
using Docsy.API.Interfaces.PasswordUtility;
using Docsy.Persistence;
using Docsy.Persistence.Models;

namespace Docsy.API;

public static class Seed
{
    public async static Task Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
     
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
        
        if (!context.Role.Any())
        {
            var roles = new List<Role>()
            {
                new Role("Admin"),
                new Role("User")
            };
            context.Role.AddRange(roles);

        }

        if (!context.User.Any())
        {
            string initSeededAdminPassword = SeedOptions.ADMIN_PASSWORD;
            var passwordUtility = scope.ServiceProvider.GetRequiredService<IPasswordUtility>();

            var hashedPw = passwordUtility.Hash(initSeededAdminPassword);

            var dbPasswordValue = $"{hashedPw.Salt}:{hashedPw.Hash}";

            var user = new User(
                SeedOptions.ADMIN_USERNAME,
                dbPasswordValue,
                SeedOptions.ADMIN_EMAIL);

            context.Add(user);
        }

        await context.SaveChangesAsync();
    }
}