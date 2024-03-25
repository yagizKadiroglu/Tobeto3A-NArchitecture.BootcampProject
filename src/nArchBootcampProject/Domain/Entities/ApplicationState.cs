using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationState : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Application> Applications { get; set; }

    public ApplicationState()
    {
        Applications = new HashSet<Application>();
    }

    public ApplicationState(Guid id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }
}
