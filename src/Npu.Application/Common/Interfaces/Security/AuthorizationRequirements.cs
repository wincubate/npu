using Npu.Domain.Tokens;

namespace Npu.Application.Common.Interfaces.Security;

public record class AuthorizationRequirements
{
    public IReadOnlyCollection<Permission> RequiredPermissions { get; init; } = [];
    public IReadOnlyCollection<Role> RequiredRoles { get; init; } = [];
    public IReadOnlyCollection<string> RequiredPolicyNames { get; init; } = [];
}
