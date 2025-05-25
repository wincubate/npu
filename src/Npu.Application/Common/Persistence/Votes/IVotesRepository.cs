using Npu.Domain.Votes;

namespace Npu.Application.Common.Persistence.Votes;

public interface IVotesRepository
{
    Task AddAsync(Vote vote, CancellationToken cancellationToken);
    Task<Vote[]> GetAllBySubmissionId(Guid submissionId, CancellationToken cancellationToken);
}
