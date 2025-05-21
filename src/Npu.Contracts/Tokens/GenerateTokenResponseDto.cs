namespace Npu.Contracts.Tokens;

public record class GenerateTokenResponseDto
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Token { get; init; }
}