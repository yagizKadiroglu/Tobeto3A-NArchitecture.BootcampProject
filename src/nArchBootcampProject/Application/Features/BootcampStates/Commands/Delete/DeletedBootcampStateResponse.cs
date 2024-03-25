using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampStates.Commands.Delete;

public class DeletedBootcampStateResponse : IResponse
{
    public Guid Id { get; set; }
}
