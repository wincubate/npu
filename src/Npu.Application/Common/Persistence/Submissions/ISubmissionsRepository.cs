using Npu.Domain.Submissions;

namespace Npu.Application.Common.Persistence.Submissions;

public interface ISubmissionsRepository
{
    Task<Submission?> GetByIdAsync(Guid submissionId, CancellationToken cancellationToken);
    Task<Submission[]> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<Submission[]> GetAllByItemNameAsync(string itemName, CancellationToken cancellationToken);
    Task<Submission[]> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Submission submission, CancellationToken cancellationToken);
    Task UpdateAsync(Submission submission, CancellationToken cancellationToken);
}
