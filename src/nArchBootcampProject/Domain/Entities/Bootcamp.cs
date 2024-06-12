using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Bootcamp : Entity<Guid>
{
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public Guid InstructorId { get; set; }
    public Guid BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual Instructor Instructor { get; set; }
    public virtual BootcampState BootcampState { get; set; }

    public virtual ICollection<Application> Applications { get; set; }

    public Bootcamp()
    {
        Applications = new HashSet<Application>();
    }

    public Bootcamp(Guid id, string name, Guid instructorId, Guid bootcampStateId, DateTime startDate, DateTime endDate)
        : this()
    {
        Id = id;
        Name = name;
        InstructorId = instructorId;
        BootcampStateId = bootcampStateId;
        StartDate = startDate;
        EndDate = endDate;
    }
}
