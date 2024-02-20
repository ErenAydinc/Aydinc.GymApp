using Application.Features.PersonalTrainers.Constants;
using Application.Services.PersonalTrainerService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.PersonalTrainers.Queries.GetList;

public class GetListPersonalTrainerQuery : IRequest<GetListResponse<GetListPersonalTrainerListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [PersonalTrainersOperationClaims.Read];

    public GetListPersonalTrainerQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListPersonalTrainerQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public class GetListPersonalTrainerQueryHandler : IRequestHandler<GetListPersonalTrainerQuery, GetListResponse<GetListPersonalTrainerListItemDto>>
    {
        private readonly IPersonalTrainerService _personalTrainerService;
        private readonly IMapper _mapper;

        public GetListPersonalTrainerQueryHandler(IPersonalTrainerService personalTrainerService, IMapper mapper)
        {
            _personalTrainerService = personalTrainerService;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPersonalTrainerListItemDto>> Handle(GetListPersonalTrainerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PersonalTrainer<int>>? personalTrainers = await _personalTrainerService.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPersonalTrainerListItemDto> response = _mapper.Map<GetListResponse<GetListPersonalTrainerListItemDto>>(personalTrainers);
            return response;
        }
    }
}
