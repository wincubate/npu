using System.Text.Json.Serialization;

namespace Npu.Contracts.Submissions;

public record class CreateSubmissionResponseDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("userId")]
    public required Guid UserId { get; init; }

    [JsonPropertyName("createdTime")]
    public required DateTimeOffset CreatedTime { get; init; }
}