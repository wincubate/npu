using Npu.Application.Votes.Get;
using Npu.Contracts.Votes;
using Npu.Domain.Votes;

namespace Npu.Api.Endpoints.Votes.Get;

internal static class GetVotesMapper
{
    public static GetVotesQuery MapFrom(this Guid userId, Guid submissionId)
        => new()
        {
            UserId = new(userId),
            SubmissionId = submissionId
        };

    public static GetVotesResponseDto MapTo(this GetVotesQueryResult queryResult) =>
        new()
        {
            Votes = [..queryResult.Votes.Select(MapTo)]
        };

    private static VoteDto MapTo(this Vote vote) =>
        new()
        {
            UserId = vote.UserId,
            CreativityScore = vote.CreativityScore,
            UniquenessScore = vote.UniquenessScore
        };
}
