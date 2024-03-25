using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBootcampStateRepository : IAsyncRepository<BootcampState, Guid>, IRepository<BootcampState, Guid> { }
