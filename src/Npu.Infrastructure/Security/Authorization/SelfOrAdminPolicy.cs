using Npu.Application.Common.Security.Requests;
using Npu.Application.Common.Security.Roles;

namespace Npu.Infrastructure.Security.Authorization;

internal class SelfOrAdminPolicy : IPolicy
{
    public bool Check<T>(IAuthorizableRequest<T> request, Principal principal)
    {
        if( request.UserId == principal.Identity.Id ||
            principal.Roles.Contains(Role.Admin))
        {
            return true;
        }
        return false;
    }
}
