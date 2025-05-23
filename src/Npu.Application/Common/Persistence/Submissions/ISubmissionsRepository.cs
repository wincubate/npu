using Npu.Domain.Submissions;

namespace Npu.Application.Common.Persistence.Submissions;

public interface ISubmissionsRepository
{
    Task AddAsync(Submission submission, CancellationToken cancellationToken);
}
