using Npu.Application.Common.Security.Requests;

namespace Npu.Application.Common.Interfaces.Security;

public interface IAuthorizationService
{
    void Authorize<T>(
        IAuthorizableRequest<T> request,
        AuthorizationRequirements requirements
    );
}