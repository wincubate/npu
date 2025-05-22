using Npu.Application.Common.Security.Permissions;
using Npu.Application.Common.Security.Roles;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Infrastructure.Security.Authorization;

public record class Principal
{
    public required Identity Identity { get; init; }

    public required IReadOnlyCollection<Permission> Permissions { get; init; }
    public required IReadOnlyCollection<Role> Roles { get; init; }

    public Principal()
    {        
    }

    [SetsRequiredMembers]
    public Principal(
        Identity identity,
        IReadOnlyCollection<Permission> permissions,
        IReadOnlyCollection<Role> roles
    )
    {
        Identity = identity;
        Permissions = permissions;  
        Roles = roles;  
    }
}
