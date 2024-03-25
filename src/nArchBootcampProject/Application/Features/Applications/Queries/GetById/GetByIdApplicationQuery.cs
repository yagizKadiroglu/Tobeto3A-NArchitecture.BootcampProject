using Application.Features.Applications.Constants;
using Application.Features.Applications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Applications.Constants.ApplicationsOperationClaims;

namespace Application.Features.Applications.Queries.GetById;

public class GetByIdApplicationQuery : IRequest<GetByIdApplicationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdApplicationQueryHandler : IRequestHandler<GetByIdApplicationQuery, GetByIdApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository _applicationRepository;
        private readonly ApplicationBusinessRules _applicationBusinessRules;

        public GetByIdApplicationQueryHandler(IMapper mapper, IApplicationRepository applicationRepository, ApplicationBusinessRules applicationBusinessRules)
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
            _applicationBusinessRules = applicationBusinessRules;
        }

        public async Task<GetByIdApplicationResponse> Handle(GetByIdApplicationQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Application? application = await _applicationRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationBusinessRules.ApplicationShouldExistWhenSelected(application);

            GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
            return response;
        }
    }
}