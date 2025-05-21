using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Tokens;

public readonly record struct TokenId : IStronglyTypedId<Guid>
{
    public static TokenId New() => new(Guid.NewGuid());
    public static implicit operator Guid(TokenId id) => id.Value;
    
    public required Guid Value { get; init; }

    [SetsRequiredMembers]
    public TokenId(Guid value)
    {
        Value = value;
    }
}
