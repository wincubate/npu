using Npu.Domain.Submissions;

namespace Npu.Application.Common.Persistence.Submissions;

public interface ISubmissionsRepository
{
    Task<Submission?> GetByIdAsync(Guid submissionId, CancellationToken cancellationToken);
    Task AddAsync(Submission submission, CancellationToken cancellationToken);
    Task UpdateAsync(Submission submission, CancellationToken cancellationToken);
}
