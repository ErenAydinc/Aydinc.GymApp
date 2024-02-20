using Core.Application.Dtos;

namespace Application.Features.PersonalTrainers.Queries.GetList;

public class GetListPersonalTrainerListItemDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public GetListPersonalTrainerListItemDto()
    {
    }

    public GetListPersonalTrainerListItemDto(int id, int userId)
    {
        Id = id;
        UserId = userId;
    }
}
