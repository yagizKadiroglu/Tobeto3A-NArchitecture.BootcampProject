using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;

namespace Application.Features.Bootcamps.Commands.Delete;

public class DeleteBootcampCommand : IRequest<DeletedBootcampResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BootcampsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcamps"];

    public class DeleteBootcampCommandHandler : IRequestHandler<DeleteBootcampCommand, DeletedBootcampResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampRepository _bootcampRepository;
        private readonly BootcampBusinessRules _bootcampBusinessRules;
        private readonly ImageServiceBase _imageServiceAdapter;

        public DeleteBootcampCommandHandler(
            IMapper mapper,
            IBootcampRepository bootcampRepository,
            BootcampBusinessRules bootcampBusinessRules
,
            ImageServiceBase imageServiceAdapter)
        {
            _mapper = mapper;
            _bootcampRepository = bootcampRepository;
            _bootcampBusinessRules = bootcampBusinessRules;
            _imageServiceAdapter = imageServiceAdapter;
        }

        public async Task<DeletedBootcampResponse> Handle(DeleteBootcampCommand request, CancellationToken cancellationToken)
        {
            Bootcamp? bootcamp = await _bootcampRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampBusinessRules.BootcampShouldExistWhenSelected(bootcamp);

            await _imageServiceAdapter.DeleteAsync(bootcamp!.ImagePath);
            await _bootcampRepository.DeleteAsync(bootcamp!);

            DeletedBootcampResponse response = _mapper.Map<DeletedBootcampResponse>(bootcamp);
            return response;
        }
    }
}
