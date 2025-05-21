namespace Npu.Domain.Tokens;

public record class Identification
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
}