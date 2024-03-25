using Application.Features.Applications.Constants;
using Application.Features.Applications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.Applications.Constants.ApplicationsOperationClaims;

namespace Application.Features.Applications.Commands.Create;

public class CreateApplicationCommand
    : IRequest<CreatedApplicationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest
{
    public Guid ApplicantId { get; set; }
    public Guid BootcampId { get; set; }
    public Guid ApplicationStateId { get; set; }

    public string[] Roles => [Admin, Write, ApplicationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplications"];

    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, CreatedApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository _applicationRepository;
        private readonly ApplicationBusinessRules _applicationBusinessRules;

        public CreateApplicationCommandHandler(
            IMapper mapper,
            IApplicationRepository applicationRepository,
            ApplicationBusinessRules applicationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
            _applicationBusinessRules = applicationBusinessRules;
        }

        public async Task<CreatedApplicationResponse> Handle(
            CreateApplicationCommand request,
            CancellationToken cancellationToken
        )
        {
            Domain.Entities.Application application = _mapper.Map<Domain.Entities.Application>(request);

            await _applicationRepository.AddAsync(application);

            CreatedApplicationResponse response = _mapper.Map<CreatedApplicationResponse>(application);
            return response;
        }
    }
}
