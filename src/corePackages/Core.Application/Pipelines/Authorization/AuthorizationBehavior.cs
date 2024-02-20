using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Constants;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        bool? userIsAuth = _httpContextAccessor.HttpContext.User?.Identity?.IsAuthenticated;
        ICollection<string>? userRoleClaims = _httpContextAccessor.HttpContext.User?.ClaimRoles();
        if (userIsAuth == false)
            throw new AuthorizationException("You are not authenticated./ Kimliğiniz bulunamadı.");

        bool isNotMatchedAUserRoleClaimWithRequestRoles = userRoleClaims
            .FirstOrDefault(userRoleClaim =>
                userRoleClaim == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRoleClaim)
            )
            .IsNullOrEmpty();
        if (isNotMatchedAUserRoleClaimWithRequestRoles)
            throw new AuthorizationException("You are not authorized./ Yetkili değilsiniz");

        TResponse response = await next();
        return response;
    }
}
