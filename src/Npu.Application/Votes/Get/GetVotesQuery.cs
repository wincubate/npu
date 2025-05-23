using MediatR;

namespace Npu.Application.Votes.Get;

public record class GetVotesQuery : IRequest<GetVotesQueryResult>
{
    public required Guid SubmissionId { get; init; }
}

