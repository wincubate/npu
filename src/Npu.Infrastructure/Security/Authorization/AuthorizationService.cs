using Npu.Application.Common.Security.Authorization;
using Npu.Application.Common.Security.Policies;
using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization;

internal class AuthorizationService : IAuthorizationService
{
    private readonly IPrincipalProvider _principalProvider;
    private readonly IPolicyChecker _policyChecker;

    public AuthorizationService(
        IPrincipalProvider principalProvider,
        IPolicyChecker policyChecker
    )
    {
        _principalProvider = principalProvider;
        _policyChecker = policyChecker;
    }

    public void Authorize<T>(
        IAuthorizableRequest<T> request,
        AuthorizationRequirements requirements
    )
    {
        try
        {
            Principal principal = _principalProvider.GetCurrent();

            if (requirements.Permissions
                .Except(principal.Permissions)
                .Any()
            )
            {
                string message = "User needs required permission to execute this use case";
                throw new AuthorizationException(message);
            }

            if (requirements.Roles
                .Except(principal.Roles)
                .Any()
            )
            {
                string message = "User needs required role to execute this use case";
                throw new AuthorizationException(message);
            }

            foreach (PolicyName policy in requirements.Policies)
            {
                if (_policyChecker.Check(request, principal, policy) is false)
                {
                    string message = "User does not comply with required policy";
                    throw new AuthorizationException(message);
                }
            }
        }
        catch( Exception exception)
        {
            string message = "Could not authorize";
            throw new AuthorizationException(message, exception);
        }
    }
}