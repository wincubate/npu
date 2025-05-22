using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization;

public interface IPolicy
{
    bool Check<T>(IAuthorizableRequest<T> request, Principal principal);
}
