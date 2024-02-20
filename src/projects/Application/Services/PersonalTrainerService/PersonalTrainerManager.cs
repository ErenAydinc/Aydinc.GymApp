using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PersonalTrainerService;
public class PersonalTrainerManager:IPersonalTrainerService
{
    private readonly IPersonalTrainerRepository _personalTrainerRepository;
    //private readonly PersonalTrainerBusinessRules _userPersonalTrainerBusinessRules;

    public PersonalTrainerManager(
        IPersonalTrainerRepository personalTrainerRepository
        //PersonalTrainerBusinessRules personalTrainerBusinessRules
    )
    {
        _personalTrainerRepository = personalTrainerRepository;
        //_userPersonalTrainerBusinessRules = userPersonalTrainerBusinessRules;
    }

    public async Task<PersonalTrainer<int>?> GetAsync(
        Expression<Func<PersonalTrainer<int>, bool>> predicate,
        Func<IQueryable<PersonalTrainer<int>>, IIncludableQueryable<PersonalTrainer<int>, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PersonalTrainer<int>? userPersonalTrainer = await _personalTrainerRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userPersonalTrainer;
    }

    public async Task<IPaginate<PersonalTrainer<int>>?> GetListAsync(
        Expression<Func<PersonalTrainer<int>, bool>>? predicate = null,
        Func<IQueryable<PersonalTrainer<int>>, IOrderedQueryable<PersonalTrainer<int>>>? orderBy = null,
        Func<IQueryable<PersonalTrainer<int>>, IIncludableQueryable<PersonalTrainer<int>, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PersonalTrainer<int>> userPersonalTrainerList = await _personalTrainerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userPersonalTrainerList;
    }

    public async Task<PersonalTrainer<int>> AddAsync(PersonalTrainer<int> userPersonalTrainer)
    {

        PersonalTrainer<int> addedPersonalTrainer = await _personalTrainerRepository.AddAsync(userPersonalTrainer);

        return addedPersonalTrainer;
    }

    public async Task<PersonalTrainer<int>> UpdateAsync(PersonalTrainer<int> userPersonalTrainer)
    {

        PersonalTrainer<int> updatedPersonalTrainer = await _personalTrainerRepository.UpdateAsync(
            userPersonalTrainer
        );

        return updatedPersonalTrainer;
    }

    public async Task<PersonalTrainer<int>> DeleteAsync(PersonalTrainer<int> userPersonalTrainer, bool permanent = false)
    {
        PersonalTrainer<int> deletedPersonalTrainer = await _personalTrainerRepository.DeleteAsync(
            userPersonalTrainer
        );

        return deletedPersonalTrainer;
    }
}
