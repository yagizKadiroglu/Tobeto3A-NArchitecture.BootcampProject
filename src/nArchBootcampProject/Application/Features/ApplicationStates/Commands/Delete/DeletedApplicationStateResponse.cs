using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Commands.Delete;

public class DeletedApplicationStateResponse : IResponse
{
    public Guid Id { get; set; }
}
