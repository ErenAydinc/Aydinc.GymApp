using Core.Application.Responses;

namespace Application.Features.PersonalTrainers.Commands.Create;

public class CreatedPersonalTrainerResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public CreatedPersonalTrainerResponse()
    {
    }

    public CreatedPersonalTrainerResponse(int id, int userId)
    {
        Id = id;
        UserId = userId;
    }
}
