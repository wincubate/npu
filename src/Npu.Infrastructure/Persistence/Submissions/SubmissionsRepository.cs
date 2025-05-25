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

    public async Task<Submission[]> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken) =>
        await _context.Submissions
            .Where(submission => submission.UserId == userId)
            .ToArrayAsync(cancellationToken: cancellationToken)
            ;

    public async Task<Submission[]> GetAllByItemNameAsync(string itemName, CancellationToken cancellationToken) =>
        await _context.Submissions
            .Where(submission => submission.PartName.Contains(itemName))
            .ToArrayAsync(cancellationToken: cancellationToken)
            ;

    public async Task<Submission[]> GetAllAsync(CancellationToken cancellationToken) =>
        await _context.Submissions.ToArrayAsync(cancellationToken: cancellationToken)
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
