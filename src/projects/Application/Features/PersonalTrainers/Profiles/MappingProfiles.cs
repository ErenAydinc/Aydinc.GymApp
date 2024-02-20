using Application.Features.PersonalTrainers.Commands.Create;
using Application.Features.PersonalTrainers.Commands.Delete;
using Application.Features.PersonalTrainers.Commands.Update;
using Application.Features.PersonalTrainers.Queries.GetById;
using Application.Features.PersonalTrainers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.PersonalTrainers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PersonalTrainer<int>, CreatePersonalTrainerCommand>().ReverseMap();
        CreateMap<PersonalTrainer<int>, CreatedPersonalTrainerResponse>().ReverseMap();
        CreateMap<PersonalTrainer<int>, UpdatePersonalTrainerCommand>().ReverseMap();
        CreateMap<PersonalTrainer<int>, UpdatedPersonalTrainerResponse>().ReverseMap();
        CreateMap<PersonalTrainer<int>, DeletePersonalTrainerCommand>().ReverseMap();
        CreateMap<PersonalTrainer<int>, DeletedPersonalTrainerResponse>().ReverseMap();
        CreateMap<PersonalTrainer<int>, GetByIdPersonalTrainerResponse>().ReverseMap();
        CreateMap<PersonalTrainer<int>, GetListPersonalTrainerListItemDto>().ReverseMap();
        CreateMap<IPaginate<PersonalTrainer<int>>, GetListResponse<GetListPersonalTrainerListItemDto>>().ReverseMap();
    }
}
