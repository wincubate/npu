using Microsoft.EntityFrameworkCore;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Domain.Submissions;
using Npu.Infrastructure.Common.Persistence;

namespace Npu.Infrastructure.Persistence.Submissions;

internal class SubmissionsRepository : ISubmissionsRepository
{
    private readonly NpuDbContext _context;

    public SubmissionsRepository(NpuDbContext context)
    {
        _context = context;
    }

    public async Task<Submission?> GetByIdAsync(Guid submissionId, CancellationToken cancellationToken) =>
        await _context.Submissions
            .SingleOrDefaultAsync(submission => submission.Id == submissionId, cancellationToken)
            ;

    public async Task AddAsync(Submission submission, CancellationToken cancellationToken)
    {
        await _context.AddAsync(submission, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Submission submission, CancellationToken cancellationToken)
    {
        _context.Update(submission);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
