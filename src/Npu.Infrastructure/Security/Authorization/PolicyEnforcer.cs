using Npu.Application.Common.Security.Policies;
using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization;

internal class PolicyEnforcer : IPolicyEnforcer
{
    private readonly Dictionary<string, IPolicy> _policies;

    public PolicyEnforcer()
    {
        _policies = new Dictionary<string, IPolicy>()
        {
            [PolicyNames.SelfOrAdmin] = new SelfOrAdminPolicy()
        };
    }

    public void Authorize<T>(
        IAuthorizableRequest<T> request, 
        Principal principal, 
        string policyName
    )
    {
        if( _policies[policyName].Check(request, principal) is false)
        {
            string message = "User does not comply with policy";
            throw new AuthorizationException(message);
        }
    }
}