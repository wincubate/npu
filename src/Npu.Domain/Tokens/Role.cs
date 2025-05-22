using Npu.Domain.Common;

namespace Npu.Domain.Tokens;

public record class Role(string Value) : ValueObjectBase<string>(Value)
{
    public static Role Parse(string value) => new(value);

    public override string ToString() => Value;
}
