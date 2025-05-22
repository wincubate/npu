using Npu.Application.Common.Security.Requests;

namespace Npu.Application.Common.Security.Authorization;

public interface IAuthorizationService
{
    void Authorize<T>(
        IAuthorizableRequest<T> request,
        AuthorizationRequirements requirements
    );
}
