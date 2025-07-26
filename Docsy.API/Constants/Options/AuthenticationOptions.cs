namespace Docsy.API.Constants.Options;

public class AuthenticationOptions
{
    public required string JwtSecret { get; set; } 
    public required int JwtExpirationMinutes { get; set; } 
    public required string JwtIssuer { get; set; } 
    public required string JwtAudience { get; set; }
}