using Core.Application.Responses;

namespace Application.Features.PersonalTrainers.Commands.Update;

public class UpdatedPersonalTrainerResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public UpdatedPersonalTrainerResponse()
    {
    }

    public UpdatedPersonalTrainerResponse(int id, int userId)
    {
        Id = id;
        UserId = userId;
    }
}
