using System.Linq.Expressions;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services.UserOperationClaims;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public UserOperationClaimManager(
        IUserOperationClaimRepository userOperationClaimRepository,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules
    )
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<UserOperationClaim<int, int>?> GetAsync(
        Expression<Func<UserOperationClaim<int, int>, bool>> predicate,
        Func<IQueryable<UserOperationClaim<int, int>>, IIncludableQueryable<UserOperationClaim<int, int>, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserOperationClaim<int, int>? userUserOperationClaim = await _userOperationClaimRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaim;
    }

    public async Task<IPaginate<UserOperationClaim<int, int>>?> GetListAsync(
        Expression<Func<UserOperationClaim<int, int>, bool>>? predicate = null,
        Func<IQueryable<UserOperationClaim<int, int>>, IOrderedQueryable<UserOperationClaim<int, int>>>? orderBy = null,
        Func<IQueryable<UserOperationClaim<int, int>>, IIncludableQueryable<UserOperationClaim<int, int>, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserOperationClaim<int, int>> userUserOperationClaimList = await _userOperationClaimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaimList;
    }

    public async Task<UserOperationClaim<int, int>> AddAsync(UserOperationClaim<int, int> userUserOperationClaim)
    {
        await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim<int, int> addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userUserOperationClaim);

        return addedUserOperationClaim;
    }

    public async Task<UserOperationClaim<int, int>> UpdateAsync(UserOperationClaim<int, int> userUserOperationClaim)
    {
        await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenUpdated(
            userUserOperationClaim.Id,
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim<int, int> updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(
            userUserOperationClaim
        );

        return updatedUserOperationClaim;
    }

    public async Task<UserOperationClaim<int, int>> DeleteAsync(UserOperationClaim<int, int> userUserOperationClaim, bool permanent = false)
    {
        UserOperationClaim<int, int> deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(
            userUserOperationClaim
        );

        return deletedUserOperationClaim;
    }
}
