using Npu.Domain.Common;

namespace Npu.Domain.Tokens;

public record class Role(string value) : ValueObjectBase<string>(value)
{
    public override string ToString() => Value;
}
