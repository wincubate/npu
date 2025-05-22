using Npu.Domain.Common;

namespace Npu.Application.Common.Security.Tokens;

public record class Token(string value) : ValueObjectBase<string>(value)
{
    public override string ToString() => Value;
}
