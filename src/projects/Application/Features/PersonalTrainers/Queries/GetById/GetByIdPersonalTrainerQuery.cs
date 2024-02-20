using Application.Features.PersonalTrainers.Constants;
using Application.Features.PersonalTrainers.Rules;
using Application.Services.PersonalTrainerService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.PersonalTrainers.Queries.GetById;

public class GetByIdPersonalTrainerQuery : IRequest<GetByIdPersonalTrainerResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [PersonalTrainersOperationClaims.Read];

    public class GetByIdPersonalTrainerQueryHandler : IRequestHandler<GetByIdPersonalTrainerQuery, GetByIdPersonalTrainerResponse>
    {
        private readonly IPersonalTrainerService _personalTrainerService;
        private readonly IMapper _mapper;
        private readonly PersonalTrainerBusinessRules _personalTrainerBusinessRules;

        public GetByIdPersonalTrainerQueryHandler(IPersonalTrainerService personalTrainerService, IMapper mapper, PersonalTrainerBusinessRules personalTrainerBusinessRules)
        {
            _personalTrainerService = personalTrainerService;
            _mapper = mapper;
            _personalTrainerBusinessRules = personalTrainerBusinessRules;
        }

        public async Task<GetByIdPersonalTrainerResponse> Handle(GetByIdPersonalTrainerQuery request, CancellationToken cancellationToken)
        {
            PersonalTrainer<int>? personalTrainer = await _personalTrainerService.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _personalTrainerBusinessRules.PersonalTrainerIsExists(personalTrainer.UserId,false);

            GetByIdPersonalTrainerResponse response = _mapper.Map<GetByIdPersonalTrainerResponse>(personalTrainer);
            return response;
        }
    }
}
