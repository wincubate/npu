using MediatR;

namespace Npu.Application.Tokens.Generate;

public record class GenerateTokenCommand : IRequest<GenerateTokenCommandResult>
{
    public Guid? Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required IReadOnlyCollection<string> Permissions { get; init; }
    public required IReadOnlyCollection<string> Roles { get; init; }
}
