using Npu.Domain.Common;

namespace Npu.Application.Common.Security.Roles;

public record class Role(string Value) : ValueObjectBase<string>(Value)
{
    public static Role Admin { get; } = new(RoleNames.Admin);

    public static Role Parse(string value) => new(value);

    public override string ToString() => Value;
}
