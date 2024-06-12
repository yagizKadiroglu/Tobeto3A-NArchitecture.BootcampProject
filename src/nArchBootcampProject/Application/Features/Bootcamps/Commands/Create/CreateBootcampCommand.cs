using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;
using Application.Services.ImageService;

namespace Application.Features.Bootcamps.Commands.Create;

public class CreateBootcampCommand : IRequest<CreatedBootcampResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public Guid BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public IFormFile File { get; set; }

    public string[] Roles => [Admin, Write, BootcampsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcamps"];

    public class CreateBootcampCommandHandler : IRequestHandler<CreateBootcampCommand, CreatedBootcampResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampRepository _bootcampRepository;
        private readonly BootcampBusinessRules _bootcampBusinessRules;
        private readonly ImageServiceBase _imageServiceAdapter;

        public CreateBootcampCommandHandler(
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

        public async Task<CreatedBootcampResponse> Handle(CreateBootcampCommand request, CancellationToken cancellationToken)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            bootcamp.ImagePath = await _imageServiceAdapter.UploadAsync(request.File);

            await _bootcampRepository.AddAsync(bootcamp);

            CreatedBootcampResponse response = _mapper.Map<CreatedBootcampResponse>(bootcamp);
            return response;
        }
    }
}
