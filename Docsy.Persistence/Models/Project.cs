namespace Docsy.Persistence.Models;

public class Project : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Team>? Teams { get; set; } 
    public Project(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}
