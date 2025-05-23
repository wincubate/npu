using Npu.Domain.Votes;

namespace Npu.Application.Votes.Get;

public record class GetVotesQueryResult
{
    public required IReadOnlyCollection<Vote> Votes { get; init; }
}
