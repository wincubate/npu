using Npu.Domain.Common;

namespace Npu.Domain.Tokens;

public record class Permission(string Value) : ValueObjectBase<string>(Value)
{
    public static Permission Parse(string value) => new(value);

    public override string ToString() => Value;
}
