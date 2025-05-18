using System.Text.Json.Serialization;

namespace Npu.Contracts;

public record class CreateResponseDto
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("createdTime")]
    public required DateTimeOffset CreatedTime { get; init; }
}