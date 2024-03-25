using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Applications.Queries.GetList;

public class GetListApplicationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid BootcampId { get; set; }
    public Guid ApplicationStateId { get; set; }
}
