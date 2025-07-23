namespace Docsy.Persistence.Models;

public class User : BaseEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public ICollection<Role>? Roles { get; set; }
    public ICollection<Team>? Teams { get; set; }
    public User(string username, string passwordHash, string email)
    {
        Id = Guid.NewGuid();
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
        CreatedAt = DateTime.UtcNow;
    }
}