using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBlackListRepository : IAsyncRepository<BlackList, Guid>, IRepository<BlackList, Guid>
{
}