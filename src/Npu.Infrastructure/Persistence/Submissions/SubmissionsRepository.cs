using Npu.Application.Common.Persistence.Submissions;
using Npu.Domain.Submissions;
using Npu.Domain.Votes;
using Npu.Infrastructure.Common.Persistence;

namespace Npu.Infrastructure.Persistence.Submissions;

internal class SubmissionsRepository : ISubmissionsRepository
{
    private readonly NpuDbContext _context;

    public SubmissionsRepository(NpuDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Submission submission, CancellationToken cancellationToken)
    {
        await _context.Submissions.AddAsync(submission, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
