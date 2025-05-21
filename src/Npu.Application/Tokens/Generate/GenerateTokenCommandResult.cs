using Npu.Domain.Tokens;

namespace Npu.Application.Tokens.Generate;

public record class GenerateTokenCommandResult
{
    public required TokenId TokenId { get; init; }
    public required Token Token { get; init; }
    public required Identification Identification { get; init; }
}
