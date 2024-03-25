using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationStates.Queries.GetList;

public class GetListApplicationStateListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
