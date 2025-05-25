using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Votes;

public class Vote : Entity
{
    public required Guid UserId { get; init; }
    public required Guid SubmissionId { get; init; }

    public required int CreativityScore { get; init; }
    public required int UniquenessScore { get; init; }

    public Vote()
    {            
    }

    [SetsRequiredMembers]
    public Vote(
        Guid userId,
        Guid submissionId,
        int creativityScore,
        int uniquenessScore,
        Guid? id = null
    ) : base(id ?? Guid.CreateVersion7())
    {
        UserId = userId;
        SubmissionId = submissionId;
        CreativityScore = creativityScore;
        UniquenessScore = uniquenessScore;
    }
}