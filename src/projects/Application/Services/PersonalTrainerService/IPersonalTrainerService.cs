using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PersonalTrainerService;
public interface IPersonalTrainerService
{
    Task<PersonalTrainer<int>?> GetAsync(
        Expression<Func<PersonalTrainer<int>, bool>> predicate,
        Func<IQueryable<PersonalTrainer<int>>, IIncludableQueryable<PersonalTrainer<int>, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<PersonalTrainer<int>>?> GetListAsync(
        Expression<Func<PersonalTrainer<int>, bool>>? predicate = null,
        Func<IQueryable<PersonalTrainer<int>>, IOrderedQueryable<PersonalTrainer<int>>>? orderBy = null,
        Func<IQueryable<PersonalTrainer<int>>, IIncludableQueryable<PersonalTrainer<int>, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<PersonalTrainer<int>> AddAsync(PersonalTrainer<int> personalTrainer);
    Task<PersonalTrainer<int>> UpdateAsync(PersonalTrainer<int> personalTrainer);
    Task<PersonalTrainer<int>> DeleteAsync(PersonalTrainer<int> personalTrainer, bool permanent = false);
}
