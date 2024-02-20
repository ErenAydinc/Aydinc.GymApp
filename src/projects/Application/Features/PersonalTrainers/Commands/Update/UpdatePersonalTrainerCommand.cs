using Application.Features.PersonalTrainers.Constants;
using Application.Features.PersonalTrainers.Rules;
using Application.Services.PersonalTrainerService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using static Application.Features.PersonalTrainers.Constants.PersonalTrainersOperationClaims;

namespace Application.Features.PersonalTrainers.Commands.Update;

public class UpdatePersonalTrainerCommand : IRequest<UpdatedPersonalTrainerResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public UpdatePersonalTrainerCommand()
    {
    }

    public UpdatePersonalTrainerCommand(int id,int userId)
    {
        Id = id;
        UserId = UserId;
    }

    public string[] Roles => new[] { Admin, Write, PersonalTrainersOperationClaims.Update };

    public class UpdatePersonalTrainerCommandHandler : IRequestHandler<UpdatePersonalTrainerCommand, UpdatedPersonalTrainerResponse>
    {
        private readonly IPersonalTrainerService _personalTrainerService;
        private readonly IMapper _mapper;
        private readonly PersonalTrainerBusinessRules _personalTrainerBusinessRules;

        public UpdatePersonalTrainerCommandHandler(IPersonalTrainerService personalTrainerService, IMapper mapper, PersonalTrainerBusinessRules personalTrainerBusinessRules)
        {
            _personalTrainerService = personalTrainerService;
            _mapper = mapper;
            _personalTrainerBusinessRules = personalTrainerBusinessRules;
        }

        public async Task<UpdatedPersonalTrainerResponse> Handle(UpdatePersonalTrainerCommand request, CancellationToken cancellationToken)
        {
            PersonalTrainer<int>? personalTrainer = await _personalTrainerService.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
            await _personalTrainerBusinessRules.PersonalTrainerIsExists(personalTrainer.UserId,false);
            personalTrainer = _mapper.Map(request, personalTrainer);

            await _personalTrainerService.UpdateAsync(personalTrainer);

            UpdatedPersonalTrainerResponse response = _mapper.Map<UpdatedPersonalTrainerResponse>(personalTrainer);
            return response;
        }
    }
}
