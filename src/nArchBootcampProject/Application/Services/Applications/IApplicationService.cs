using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Applications;

public interface IApplicationService
{
    Task<Domain.Entities.Application?> GetAsync(
        Expression<Func<Domain.Entities.Application, bool>> predicate,
        Func<IQueryable<Domain.Entities.Application>, IIncludableQueryable<Domain.Entities.Application, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Domain.Entities.Application>?> GetListAsync(
        Expression<Func<Domain.Entities.Application, bool>>? predicate = null,
        Func<IQueryable<Domain.Entities.Application>, IOrderedQueryable<Domain.Entities.Application>>? orderBy = null,
        Func<IQueryable<Domain.Entities.Application>, IIncludableQueryable<Domain.Entities.Application, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Domain.Entities.Application> AddAsync(Domain.Entities.Application application);
    Task<Domain.Entities.Application> UpdateAsync(Domain.Entities.Application application);
    Task<Domain.Entities.Application> DeleteAsync(Domain.Entities.Application application, bool permanent = false);
}
