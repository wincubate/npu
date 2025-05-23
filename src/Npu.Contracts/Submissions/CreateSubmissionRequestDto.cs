using System.Text.Json.Serialization;

namespace Npu.Contracts.Submissions;

public record class CreateSubmissionRequestDto
{
    [JsonPropertyName("userId")]
    public required Guid UserId { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("itemNumbers")]
    public required string[] ItemNumbers { get; init; }
}
