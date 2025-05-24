using Npu.Domain.Users;

namespace Npu.Application.Common.Persistence.Users;

public interface IUsersRepository
{
    Task<bool> ExistsAsync(IdentityId userId, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(IdentityId userId, CancellationToken cancellationToken);
}
