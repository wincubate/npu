using Npu.Domain.Common;

namespace Npu.Application.Common.Security.Policies;

public record class PolicyName(string Value) : ValueObjectBase<string>(Value)
{
    public static PolicyName Parse(string value) => new(value);

    public override string ToString() => Value;
}