using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bootcamps.Commands.Delete;

public class DeletedBootcampResponse : IResponse
{
    public Guid Id { get; set; }
}
