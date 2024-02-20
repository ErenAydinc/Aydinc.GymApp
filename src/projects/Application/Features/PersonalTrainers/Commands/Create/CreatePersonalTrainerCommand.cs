using Application.Features.PersonalTrainers.Rules;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using static Application.Features.PersonalTrainers.Constants.PersonalTrainersOperationClaims;

namespace Application.Features.PersonalTrainers.Commands.Create;

public class CreatePersonalTrainerCommand : IRequest<CreatedPersonalTrainerResponse>, ISecuredRequest
{
    public int? UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public CreatePersonalTrainerCommand()
    {
    }

    public CreatePersonalTrainerCommand(int? userId,string firstName,string lastName,string email,string password)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string[] Roles => new[] { Admin, Write, Add };

    public class CreatePersonalTrainerCommandHandler : IRequestHandler<CreatePersonalTrainerCommand, CreatedPersonalTrainerResponse>
    {
        private readonly IPersonalTrainerRepository _personalTrainerRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly PersonalTrainerBusinessRules _personalTrainerBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;
        public CreatePersonalTrainerCommandHandler(IPersonalTrainerRepository personalTrainerRepository, IMapper mapper, PersonalTrainerBusinessRules personalTrainerBusinessRules, UserBusinessRules userBusinessRules, IUserService userService)
        {
            _personalTrainerRepository = personalTrainerRepository;
            _mapper = mapper;
            _personalTrainerBusinessRules = personalTrainerBusinessRules;
            _userBusinessRules = userBusinessRules;
            _userService = userService;
        }

        public async Task<CreatedPersonalTrainerResponse> Handle(CreatePersonalTrainerCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);
            User<int, int> user = _mapper.Map<User<int, int>>(request);

            HashingHelper.CreatePasswordHash(
                request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            User<int, int> createdUser = await _userService.AddAsync(user);

            CreatedUserResponse userResponse = _mapper.Map<CreatedUserResponse>(createdUser);

            await _personalTrainerBusinessRules.PersonalTrainerIsExists(userResponse.Id);
            PersonalTrainer<int> personalTrainer = _mapper.Map<PersonalTrainer<int>>(request);

            PersonalTrainer<int> createdPersonalTrainer = await _personalTrainerRepository.AddAsync(personalTrainer);

            CreatedPersonalTrainerResponse response = _mapper.Map<CreatedPersonalTrainerResponse>(createdPersonalTrainer);
            return response;
        }
    }
}
