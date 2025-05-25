using System.Text.Json.Serialization;

namespace Npu.Contracts.Tokens.Generate;

public record class GenerateTokenRequestDto
{
    [JsonPropertyName("id")]
    public Guid? Id { get; init; }

    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("permissions")]
    public required IReadOnlyCollection<string> Permissions { get; init; }

    [JsonPropertyName("roles")]
    public required IReadOnlyCollection<string> Roles { get; init; }
}
