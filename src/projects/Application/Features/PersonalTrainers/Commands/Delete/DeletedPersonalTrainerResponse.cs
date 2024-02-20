using Core.Application.Responses;

namespace Application.Features.PersonalTrainers.Commands.Delete;

public class DeletedPersonalTrainerResponse : IResponse
{
    public int Id { get; set; }
}
