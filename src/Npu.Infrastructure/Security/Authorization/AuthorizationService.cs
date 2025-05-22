using Npu.Application.Common.Interfaces.Security;
using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization;

internal class AuthorizationService : IAuthorizationService
{
    private readonly IPrincipalProvider _principalProvider;

    public AuthorizationService(IPrincipalProvider principalProvider)
    {
        _principalProvider = principalProvider;
    }

    public void Authorize<T>(IAuthorizableRequest<T> request, AuthorizationRequirements requirements)
    {
        Principal principal = _principalProvider.GetCurrent();

        if (requirements.RequiredPermissions
            .Except(principal.Permissions)
            .Any()
        )
        {
            string message = "User needs required permission to execute this use case";
            throw new AuthorizationException(message);
        }

        if (requirements.RequiredRoles
            .Except(principal.Roles)
            .Any()
        )
        {
            string message = "User needs required role to execute this use case";
            throw new AuthorizationException(message);
        }

        //foreach (var policy in requiredPolicies)
        //{
        //    var authorizationAgainstPolicyResult = _policyEnforcer.Authorize(request, currentUser, policy);

        //    if (authorizationAgainstPolicyResult.IsError)
        //    {
        //        return authorizationAgainstPolicyResult.Errors;
        //    }
        //}

    }
}