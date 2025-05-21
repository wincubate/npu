using Npu.Domain.Common;

namespace Npu.Domain.Tokens;

public record class Permission(string value) : ValueObjectBase<string>(value)
{
    public override string ToString() => Value;
}
