namespace Npu.Domain.Users;

public record class Identification
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
}