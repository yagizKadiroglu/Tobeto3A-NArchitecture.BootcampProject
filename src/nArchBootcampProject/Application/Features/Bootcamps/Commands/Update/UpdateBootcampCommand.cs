using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;

namespace Application.Features.Bootcamps.Commands.Update;

public class UpdateBootcampCommand : IRequest<UpdatedBootcampResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public Guid BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public IFormFile? File { get; set; }


    public string[] Roles => [Admin, Write, BootcampsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcamps"];

    public class UpdateBootcampCommandHandler : IRequestHandler<UpdateBootcampCommand, UpdatedBootcampResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampRepository _bootcampRepository;
        private readonly BootcampBusinessRules _bootcampBusinessRules;
        private readonly ImageServiceBase _imageServiceAdapter;

        public UpdateBootcampCommandHandler(
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

        public async Task<UpdatedBootcampResponse> Handle(UpdateBootcampCommand request, CancellationToken cancellationToken)
        {
            Bootcamp? bootcamp = await _bootcampRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampBusinessRules.BootcampShouldExistWhenSelected(bootcamp);

            bootcamp = _mapper.Map(request, bootcamp);
            if (request.File is not null)
            {
               var newPath = await _imageServiceAdapter.UpdateAsync(request.File, bootcamp!.ImagePath);
                bootcamp.ImagePath = newPath;

            }

            await _bootcampRepository.UpdateAsync(bootcamp!);

            UpdatedBootcampResponse response = _mapper.Map<UpdatedBootcampResponse>(bootcamp);
            return response;
        }
    }
}
