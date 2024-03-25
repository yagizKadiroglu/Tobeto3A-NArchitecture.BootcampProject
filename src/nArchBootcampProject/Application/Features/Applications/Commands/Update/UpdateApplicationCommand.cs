using Application.Features.Applications.Constants;
using Application.Features.Applications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.Applications.Constants.ApplicationsOperationClaims;

namespace Application.Features.Applications.Commands.Update;

public class UpdateApplicationCommand : IRequest<UpdatedApplicationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid BootcampId { get; set; }
    public Guid ApplicationStateId { get; set; }

    public string[] Roles => [Admin, Write, ApplicationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplications"];

    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, UpdatedApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository _applicationRepository;
        private readonly ApplicationBusinessRules _applicationBusinessRules;

        public UpdateApplicationCommandHandler(IMapper mapper, IApplicationRepository applicationRepository,
                                         ApplicationBusinessRules applicationBusinessRules)
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
            _applicationBusinessRules = applicationBusinessRules;
        }

        public async Task<UpdatedApplicationResponse> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Application? application = await _applicationRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationBusinessRules.ApplicationShouldExistWhenSelected(application);
            application = _mapper.Map(request, application);

            await _applicationRepository.UpdateAsync(application!);

            UpdatedApplicationResponse response = _mapper.Map<UpdatedApplicationResponse>(application);
            return response;
        }
    }
}