using System.Text.Json.Serialization;

namespace Npu.Contracts;

public record class UploadImageResponseDto
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("uri")]
    public required Uri Uri { get; init; }

    [JsonPropertyName("createdTime")]
    public required DateTimeOffset CreatedTime { get; init; }
}
