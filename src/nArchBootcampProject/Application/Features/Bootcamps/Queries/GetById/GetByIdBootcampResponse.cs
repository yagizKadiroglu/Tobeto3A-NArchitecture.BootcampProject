using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bootcamps.Queries.GetById;

public class GetByIdBootcampResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public Guid BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ImagePath { get; set; }

}
