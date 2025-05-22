using System.Text.Json.Serialization;

namespace Npu.Contracts.Tokens;

public record class GenerateTokenResponseDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }

    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("token")]
    public required string Token { get; init; }
}