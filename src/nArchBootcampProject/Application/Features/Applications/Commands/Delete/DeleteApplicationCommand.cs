using Application.Features.Applications.Constants;
using Application.Features.Applications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.Applications.Constants.ApplicationsOperationClaims;

namespace Application.Features.Applications.Commands.Delete;

public class DeleteApplicationCommand
    : IRequest<DeletedApplicationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ApplicationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplications"];

    public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, DeletedApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository _applicationRepository;
        private readonly ApplicationBusinessRules _applicationBusinessRules;

        public DeleteApplicationCommandHandler(
            IMapper mapper,
            IApplicationRepository applicationRepository,
            ApplicationBusinessRules applicationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
            _applicationBusinessRules = applicationBusinessRules;
        }

        public async Task<DeletedApplicationResponse> Handle(
            DeleteApplicationCommand request,
            CancellationToken cancellationToken
        )
        {
            Domain.Entities.Application? application = await _applicationRepository.GetAsync(
                predicate: a => a.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationBusinessRules.ApplicationShouldExistWhenSelected(application);

            await _applicationRepository.DeleteAsync(application!);

            DeletedApplicationResponse response = _mapper.Map<DeletedApplicationResponse>(application);
            return response;
        }
    }
}
