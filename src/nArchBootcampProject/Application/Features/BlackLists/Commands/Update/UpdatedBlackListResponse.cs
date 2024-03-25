using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlackLists.Commands.Update;

public class UpdatedBlackListResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public Applicant Applicant { get; set; }
}
