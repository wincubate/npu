using System.Text.Json.Serialization;

namespace Npu.Contracts.Votes.Create;

public record class CreateVoteResponseDto
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("userId")]
    public required Guid UserId { get; init; }

    [JsonPropertyName("createdTime")]
    public required DateTimeOffset CreatedTime { get; init; }
}
