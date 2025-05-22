using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization;

public interface IPolicyEnforcer
{
    void Authorize<T>(
        IAuthorizableRequest<T> request,
        Principal principal,
        string policyName
    );
}
