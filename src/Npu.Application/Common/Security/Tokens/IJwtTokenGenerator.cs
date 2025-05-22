using Npu.Application.Common.Security.Permissions;
using Npu.Application.Common.Security.Roles;
using Npu.Domain.Users;

namespace Npu.Application.Common.Security.Tokens;

public interface IJwtTokenGenerator
{
    Token GenerateToken(
        TokenId tokenId,
        Identification identification,
        IReadOnlyCollection<Permission> permissions,
        IReadOnlyCollection<Role> roles
   );
}
