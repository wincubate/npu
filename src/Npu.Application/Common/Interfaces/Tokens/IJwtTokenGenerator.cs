using Npu.Domain.Tokens;

namespace Npu.Application.Common.Interfaces.Tokens;

public interface IJwtTokenGenerator
{
    Token GenerateToken(
        TokenId tokenId,
        Identification identification,
        IReadOnlyCollection<Permission> permissions,
        IReadOnlyCollection<Role> roles
   );
}
