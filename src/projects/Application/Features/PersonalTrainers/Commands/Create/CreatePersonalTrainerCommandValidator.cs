using FluentValidation;

namespace Application.Features.PersonalTrainers.Commands.Create;

public class CreatePersonalTrainerCommandValidator : AbstractValidator<CreatePersonalTrainerCommand>
{
    public CreatePersonalTrainerCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
    }
}
