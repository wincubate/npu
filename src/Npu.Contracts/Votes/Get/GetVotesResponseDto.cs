namespace Npu.Contracts.Votes.Get;

public record class GetVotesResponseDto
{
    public required IReadOnlyCollection<VoteResponseDto> Votes { get; init; }
}
