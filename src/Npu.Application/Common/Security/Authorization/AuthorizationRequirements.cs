using Npu.Application.Common.Security.Permissions;
using Npu.Application.Common.Security.Policies;
using Npu.Application.Common.Security.Roles;

namespace Npu.Application.Common.Security.Authorization;

public record class AuthorizationRequirements
{
    public IReadOnlyCollection<Permission> Permissions { get; init; } = [];
    public IReadOnlyCollection<Role> Roles { get; init; } = [];
    public IReadOnlyCollection<PolicyName> Policies { get; init; } = [];
}
