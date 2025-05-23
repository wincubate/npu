using System.Text.Json.Serialization;

namespace Npu.Contracts.Votes;

public record class CreateVoteRequestDto
{
    [JsonPropertyName("userId")]
    public required Guid UserId { get; init; }

    [JsonPropertyName("creativityScore")]
    public int CreativityScore { get; init; }

    [JsonPropertyName("uniquenessScore")]
    public int UniquenessScore { get; init; }
}
