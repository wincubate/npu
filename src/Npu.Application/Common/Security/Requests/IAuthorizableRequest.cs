using MediatR;
using Npu.Domain.Users;

namespace Npu.Application.Common.Security.Requests;

public interface IAuthorizableRequest<T> : IRequest<T>  
{
    IdentityId UserId { get; }
}
