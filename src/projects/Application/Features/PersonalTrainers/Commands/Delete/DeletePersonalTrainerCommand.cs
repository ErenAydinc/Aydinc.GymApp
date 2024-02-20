using Application.Features.PersonalTrainers.Constants;
using Application.Features.PersonalTrainers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using static Application.Features.PersonalTrainers.Constants.PersonalTrainersOperationClaims;

namespace Application.Features.PersonalTrainers.Commands.Delete;

public class DeletePersonalTrainerCommand : IRequest<DeletedPersonalTrainerResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, PersonalTrainersOperationClaims.Delete };

    public class DeletePersonalTrainerCommandHandler : IRequestHandler<DeletePersonalTrainerCommand, DeletedPersonalTrainerResponse>
    {
        private readonly IPersonalTrainerRepository _personalTrainerRepository;
        private readonly IMapper _mapper;
        private readonly PersonalTrainerBusinessRules _personalTrainerBusinessRules;

        public DeletePersonalTrainerCommandHandler(IPersonalTrainerRepository personalTrainerRepository, IMapper mapper, PersonalTrainerBusinessRules personalTrainerBusinessRules)
        {
            _personalTrainerRepository = personalTrainerRepository;
            _mapper = mapper;
            _personalTrainerBusinessRules = personalTrainerBusinessRules;
        }

        public async Task<DeletedPersonalTrainerResponse> Handle(DeletePersonalTrainerCommand request, CancellationToken cancellationToken)
        {
            PersonalTrainer<int>? personalTrainer = await _personalTrainerRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
            await _personalTrainerBusinessRules.PersonalTrainerIsExists(personalTrainer.UserId,true);

            await _personalTrainerRepository.DeleteAsync(personalTrainer!);

            DeletedPersonalTrainerResponse response = _mapper.Map<DeletedPersonalTrainerResponse>(personalTrainer);
            return response;
        }
    }
}
