using FluentValidation;

namespace Application.Features.PersonalTrainers.Commands.Update;

public class UpdatePersonalTrainerCommandValidator : AbstractValidator<UpdatePersonalTrainerCommand>
{
    public UpdatePersonalTrainerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}
