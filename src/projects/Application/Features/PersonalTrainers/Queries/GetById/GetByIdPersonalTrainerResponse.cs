using Core.Application.Responses;

namespace Application.Features.PersonalTrainers.Queries.GetById;

public class GetByIdPersonalTrainerResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public GetByIdPersonalTrainerResponse()
    {
    }

    public GetByIdPersonalTrainerResponse(int id, int userId)
    {
        Id = id;
        UserId = userId;
    }
}
