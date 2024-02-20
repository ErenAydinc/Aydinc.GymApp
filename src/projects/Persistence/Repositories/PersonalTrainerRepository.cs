using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;
public class PersonalTrainerRepository : EfRepositoryBase<PersonalTrainer<int>, int, BaseDbContext>, IPersonalTrainerRepository
{
    public PersonalTrainerRepository(BaseDbContext context) : base(context)
    {
    }
}
