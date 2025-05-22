using Npu.Application.Common.Security.Policies;
using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization;

internal class PolicyChecker : IPolicyChecker
{
    private readonly Dictionary<string, IPolicy> _policies;

    public PolicyChecker()
    {
        _policies = new Dictionary<string, IPolicy>()
        {
            [PolicyNames.SelfOrAdmin] = new SelfOrAdminPolicy()
        };
    }

    public bool Check<T>(
        IAuthorizableRequest<T> request,
        Principal principal,
        PolicyName policyName
    ) =>
        _policies[policyName].Check(request, principal);
}