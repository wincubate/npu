using MediatR;
using Npu.Application.Common.Persistence.Votes;
using Npu.Domain.Votes;

namespace Npu.Application.Votes.Get;

internal class GetVotesQueryHandler : IRequestHandler<GetVotesQuery, GetVotesQueryResult>
{
    private readonly IVotesRepository _votesRepository;

    public GetVotesQueryHandler(IVotesRepository votesRepository)
    {
        _votesRepository = votesRepository;
    }

    public async Task<GetVotesQueryResult> Handle(GetVotesQuery query, CancellationToken cancellationToken)
    {
        Vote[] votes = await _votesRepository.GetAllBySubmissionId(query.SubmissionId, cancellationToken);

        return new()
        {
            Votes = votes
        };
    }
}
