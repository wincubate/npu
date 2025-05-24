using System.Text.Json.Serialization;

namespace Npu.Contracts.Votes.Create;

public record class CreateVoteRequestDto
{
    [JsonPropertyName("creativityScore")]
    public int CreativityScore { get; init; }

    [JsonPropertyName("uniquenessScore")]
    public int UniquenessScore { get; init; }
}
