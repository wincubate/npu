using MediatR;
using Npu.Domain.Tokens;

namespace Npu.Application.Tokens.Generate;

public record class GenerateTokenCommand : IRequest<GenerateTokenCommandResult>
{
    public TokenId? TokenId { get; init; }
    public required Identification Identification { get; init; }
    public required IReadOnlyCollection<Permission> Permissions { get; init; }
    public required IReadOnlyCollection<Role> Roles { get; init; }
}
