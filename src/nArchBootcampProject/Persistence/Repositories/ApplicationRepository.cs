using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationRepository : EfRepositoryBase<Domain.Entities.Application, Guid, BaseDbContext>, IApplicationRepository
{
    public ApplicationRepository(BaseDbContext context)
        : base(context) { }
}
