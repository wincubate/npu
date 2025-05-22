using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Users;

public readonly record struct IdentityId : IStronglyTypedId<Guid>
{
    public static IdentityId Parse(string identityId) =>
        new(Guid.Parse(identityId));

    public static IdentityId New() => new(Guid.CreateVersion7());
    public static implicit operator Guid(IdentityId id) => id.Value;

    public required Guid Value { get; init; }

    [SetsRequiredMembers]
    public IdentityId(Guid value)
    {
        Value = value;
    }
}
