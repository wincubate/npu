namespace Npu.Contracts.Tokens;

public record class GenerateTokenRequestDto
{
    public Guid? Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required List<string> Permissions { get; init; }
    public required List<string> Roles { get; init; }
}
