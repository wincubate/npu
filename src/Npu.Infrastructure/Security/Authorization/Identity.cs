using Npu.Domain.Tokens;
using Npu.Domain.Users;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Infrastructure.Security.Authorization;

public record class Identity
{
    public required IdentityId Id { get; init; }
    public required Identification Identification { get; init; }

    [SetsRequiredMembers]
    public Identity(IdentityId id, Identification identification)
    {
        Id = id;
        Identification = identification;
    }
}
