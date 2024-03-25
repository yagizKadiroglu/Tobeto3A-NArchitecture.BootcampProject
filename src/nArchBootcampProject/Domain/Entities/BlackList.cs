using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BlackList : Entity<Guid>
{
    public Guid ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }

    public Applicant Applicant { get; set; }

    public BlackList() { }

    public BlackList(Guid id, Guid applicantId, string reason, DateTime date)
    {
        Id = id;
        ApplicantId = applicantId;
        Reason = reason;
        Date = date;
    }
}
