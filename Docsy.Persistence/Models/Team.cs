namespace Docsy.Persistence.Models;

public class Team : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<User>? Users { get; set; }
    public ICollection<Project>? Projects { get; set; }

    public Team(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }
}