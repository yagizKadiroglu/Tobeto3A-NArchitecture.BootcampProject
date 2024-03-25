using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Commands.Update;

public class UpdatedApplicationStateResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
