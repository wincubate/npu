﻿using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Application.Common.Security.Tokens;

public readonly record struct TokenId : IStronglyTypedId<Guid>
{
    public static TokenId New() => new(Guid.CreateVersion7());
    public static implicit operator Guid(TokenId id) => id.Value;
    
    public required Guid Value { get; init; }

    public override string ToString() => Value.ToString();

    [SetsRequiredMembers]
    public TokenId(Guid value)
    {
        Value = value;
    }
}
