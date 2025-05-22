using Npu.Domain.Common;

namespace Npu.Application.Common.Security.Permissions;

public record class Permission(string Value) : ValueObjectBase<string>(Value)
{
    public static Permission Parse(string value) => new(value);

    public override string ToString() => Value;
}
