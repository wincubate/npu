using System.Text.Json.Serialization;

namespace Npu.Contracts;

public record class CreateRequestDto
{
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("partNames")]
    public required string[] PartNames { get; init; }
}
