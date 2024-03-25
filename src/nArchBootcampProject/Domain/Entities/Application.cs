using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Application : Entity<Guid>
{
    public Guid ApplicantId { get; set; }
    public Guid BootcampId { get; set; }
    public Guid ApplicationStateId { get; set; }

    public virtual Applicant Applicant { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }
    public virtual ApplicationState ApplicationState { get; set; }

    public Application() { }

    public Application(Guid id, Guid applicantId, Guid bootcampId, Guid applicationStateid)
        : this()
    {
        Id = id;
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStateid;
    }
}
