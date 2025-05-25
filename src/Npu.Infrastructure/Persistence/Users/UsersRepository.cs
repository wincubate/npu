using Microsoft.EntityFrameworkCore;
using Npu.Application.Common.Persistence.Users;
using Npu.Domain.Users;
using Npu.Infrastructure.Common.Persistence;

namespace Npu.Infrastructure.Persistence.Users;

internal class UsersRepository : IUsersRepository
{
    private readonly NpuDbContext _context;

    public UsersRepository(NpuDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(IdentityId userId, CancellationToken cancellationToken) =>
        await _context.Users
            .AnyAsync(user => user.Id == userId.Value, cancellationToken)
            ;

    public async Task<User?> GetByIdAsync(IdentityId userId, CancellationToken cancellationToken) =>
        await _context.Users
            .SingleOrDefaultAsync(user => user.Id == userId.Value, cancellationToken)
            ;
}
