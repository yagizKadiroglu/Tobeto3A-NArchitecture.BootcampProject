using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Bootcamps.Queries.GetList;

public class GetListBootcampListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public Guid BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ImagePath { get; set; }
}
