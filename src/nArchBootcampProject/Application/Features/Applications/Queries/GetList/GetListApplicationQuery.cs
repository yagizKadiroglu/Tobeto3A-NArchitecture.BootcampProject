using Application.Features.Applications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Applications.Constants.ApplicationsOperationClaims;

namespace Application.Features.Applications.Queries.GetList;

public class GetListApplicationQuery : IRequest<GetListResponse<GetListApplicationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListApplications({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetApplications";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicationQueryHandler
        : IRequestHandler<GetListApplicationQuery, GetListResponse<GetListApplicationListItemDto>>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public GetListApplicationQueryHandler(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationListItemDto>> Handle(
            GetListApplicationQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Domain.Entities.Application> applications = await _applicationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationListItemDto> response = _mapper.Map<GetListResponse<GetListApplicationListItemDto>>(
                applications
            );
            return response;
        }
    }
}
