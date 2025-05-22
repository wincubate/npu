using Npu.Application.Common.Security.Policies;
using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization
{
    internal interface IPolicyChecker
    {
        bool Check<T>(
            IAuthorizableRequest<T> request, 
            Principal principal, 
            PolicyName policyName
        );
    }
}