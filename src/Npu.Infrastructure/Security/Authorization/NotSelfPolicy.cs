using Npu.Application.Common.Security.Requests;

namespace Npu.Infrastructure.Security.Authorization;

internal class NotSelfPolicy : IPolicy
{
    public bool Check<T>(IAuthorizableRequest<T> request, Principal principal) =>
        request.UserId != principal.Identity.Id;
}
