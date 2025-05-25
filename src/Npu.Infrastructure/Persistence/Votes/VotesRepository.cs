using Microsoft.EntityFrameworkCore;
using Npu.Application.Common.Persistence.Votes;
using Npu.Domain.Votes;
using Npu.Infrastructure.Common.Persistence;

namespace Npu.Infrastructure.Persistence.Votes;

internal class VotesRepository : IVotesRepository
{
    private readonly NpuDbContext _context;

    public VotesRepository(NpuDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Vote vote, CancellationToken cancellationToken)
    {
        await _context.Votes.AddAsync(vote, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<Vote[]> GetAllBySubmissionId(Guid submissionId, CancellationToken cancellationToken) =>
        await _context.Votes
            .Where(vote => vote.SubmissionId == submissionId)
            .ToArrayAsync(cancellationToken: cancellationToken)
            ;

    public async Task<bool> ExistsForUserIdAndSubmissionIdAsync(Guid userId, Guid submissionId, CancellationToken cancellationToken) =>
        await _context.Votes
            .AnyAsync(
                vote => vote.UserId == userId && vote.SubmissionId == submissionId, 
                cancellationToken
            )
            ;
}
