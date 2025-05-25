using System.Text.Json.Serialization;

namespace Npu.Contracts.Submissions.Create;

public record class CreateSubmissionRequestDto
{
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("brickLinkItemNumber")]
    public required string BrickLinkItemNumber { get; init; }
}
