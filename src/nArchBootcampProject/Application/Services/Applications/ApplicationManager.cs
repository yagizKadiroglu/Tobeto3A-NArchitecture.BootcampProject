using Application.Features.Applications.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Applications;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly ApplicationBusinessRules _applicationBusinessRules;

    public ApplicationManager(IApplicationRepository applicationRepository, ApplicationBusinessRules applicationBusinessRules)
    {
        _applicationRepository = applicationRepository;
        _applicationBusinessRules = applicationBusinessRules;
    }

    public async Task<Domain.Entities.Application?> GetAsync(
        Expression<Func<Domain.Entities.Application, bool>> predicate,
        Func<IQueryable<Domain.Entities.Application>, IIncludableQueryable<Domain.Entities.Application, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Domain.Entities.Application? application = await _applicationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return application;
    }

    public async Task<IPaginate<Domain.Entities.Application>?> GetListAsync(
        Expression<Func<Domain.Entities.Application, bool>>? predicate = null,
        Func<IQueryable<Domain.Entities.Application>, IOrderedQueryable<Domain.Entities.Application>>? orderBy = null,
        Func<IQueryable<Domain.Entities.Application>, IIncludableQueryable<Domain.Entities.Application, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Domain.Entities.Application> applicationList = await _applicationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationList;
    }

    public async Task<Domain.Entities.Application> AddAsync(Domain.Entities.Application application)
    {
        Domain.Entities.Application addedApplication = await _applicationRepository.AddAsync(application);

        return addedApplication;
    }

    public async Task<Domain.Entities.Application> UpdateAsync(Domain.Entities.Application application)
    {
        Domain.Entities.Application updatedApplication = await _applicationRepository.UpdateAsync(application);

        return updatedApplication;
    }

    public async Task<Domain.Entities.Application> DeleteAsync(Domain.Entities.Application application, bool permanent = false)
    {
        Domain.Entities.Application deletedApplication = await _applicationRepository.DeleteAsync(application);

        return deletedApplication;
    }
}
