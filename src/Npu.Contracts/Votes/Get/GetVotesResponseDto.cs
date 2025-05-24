namespace Npu.Contracts.Votes.Get;

public record class GetVotesResponseDto
{
    public required IReadOnlyCollection<VoteDto> Votes { get; init; }
}
