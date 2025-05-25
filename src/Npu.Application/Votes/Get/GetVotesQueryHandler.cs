using MediatR;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Persistence.Votes;
using Npu.Domain.Exceptions;
using Npu.Domain.Submissions;
using Npu.Domain.Votes;

namespace Npu.Application.Votes.Get;

internal class GetVotesQueryHandler : IRequestHandler<GetVotesQuery, GetVotesQueryResult>
{
    private readonly ISubmissionsRepository _submissionsRepository;
    private readonly IVotesRepository _votesRepository;

    public GetVotesQueryHandler(
        ISubmissionsRepository submissionsRepository,
        IVotesRepository votesRepository
    )
    {
        _submissionsRepository = submissionsRepository;
        _votesRepository = votesRepository;
    }

    public async Task<GetVotesQueryResult> Handle(GetVotesQuery query, CancellationToken cancellationToken)
    {
        Submission? submission = await _submissionsRepository.GetByIdAsync(query.SubmissionId, cancellationToken);
        if (submission is null)
        {
            string message = "Submission not found";
            throw new NotFoundException(query.SubmissionId, message);
        }

        Vote[] votes = await _votesRepository.GetAllBySubmissionId(query.SubmissionId, cancellationToken);

        return new()
        {
            Votes = votes
        };
    }
}
