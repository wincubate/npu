using Npu.Application.Common.Security.Tokens;
using Npu.Domain.Users;

namespace Npu.Application.Tokens.Generate;

public record class GenerateTokenCommandResult
{
    public required TokenId TokenId { get; init; }
    public required Token Token { get; init; }
    public required Identification Identification { get; init; }
}
