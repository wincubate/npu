using System.Text.Json.Serialization;

namespace Npu.Contracts.Submissions.Search;

public record class SearchSubmissionsResponseDto
{
    [JsonPropertyName("itemName")]
    public required string ItemName { get; init; }

    [JsonPropertyName("submissions")]
    public required IReadOnlyCollection<SubmissionResponseDto> Submissions { get; init; }
}
