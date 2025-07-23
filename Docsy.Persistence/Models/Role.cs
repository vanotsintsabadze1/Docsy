namespace Docsy.Persistence.Models;

public class Role : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}