using Application.Features.Applications.Commands.Create;
using Application.Features.Applications.Commands.Delete;
using Application.Features.Applications.Commands.Update;
using Application.Features.Applications.Queries.GetById;
using Application.Features.Applications.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Applications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Application, CreateApplicationCommand>().ReverseMap();
        CreateMap<Domain.Entities.Application, CreatedApplicationResponse>().ReverseMap();
        CreateMap<Domain.Entities.Application, UpdateApplicationCommand>().ReverseMap();
        CreateMap<Domain.Entities.Application, UpdatedApplicationResponse>().ReverseMap();
        CreateMap<Domain.Entities.Application, DeleteApplicationCommand>().ReverseMap();
        CreateMap<Domain.Entities.Application, DeletedApplicationResponse>().ReverseMap();
        CreateMap<Domain.Entities.Application, GetByIdApplicationResponse>().ReverseMap();
        CreateMap<Domain.Entities.Application, GetListApplicationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Application>, GetListResponse<GetListApplicationListItemDto>>().ReverseMap();
    }
}
