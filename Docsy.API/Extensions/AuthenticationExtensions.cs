using Docsy.API.Constants.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Docsy.API.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    {
        var authOptionsService = services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<AuthenticationOptions>>();

        var authOptions = authOptionsService.CurrentValue;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = authOptions.JwtAudience != null ? true : false,
                    ValidateIssuer = authOptions.JwtIssuer != null ? true : false,

                    // These will be valid if the options are set, otherwise they will be null and not validated
                    ValidIssuer = authOptions.JwtIssuer,
                    ValidAudience = authOptions.JwtAudience,

                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(authOptions.JwtSecret)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                };
            });

        return services;
    }
}
