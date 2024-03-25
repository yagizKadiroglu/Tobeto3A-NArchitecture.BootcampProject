using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationRepository : IAsyncRepository<Domain.Entities.Application, Guid>, IRepository<Domain.Entities.Application, Guid>
{
}