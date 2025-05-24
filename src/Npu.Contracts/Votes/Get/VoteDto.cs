using System.Text.Json.Serialization;

namespace Npu.Contracts.Votes.Get;

public record class VoteDto
{
    [JsonPropertyName("userId")]
    public required Guid UserId { get; init; }

    [JsonPropertyName("creativityScore")]
    public int CreativityScore { get; init; }

    [JsonPropertyName("uniquenessScore")]
    public int UniquenessScore { get; init; }
}