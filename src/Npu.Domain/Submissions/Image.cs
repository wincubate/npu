using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Submissions;

public class Image : Entity
{
    public required Guid UserId { get; init; }
    public required Guid SubmissionId { get; init; }
    public required string Url { get; init; }

    public Image()
    {        
    }

    [SetsRequiredMembers]
    public Image(
        Guid userId,
        Guid submissionId,
        string url,
        Guid? id = null
    ) : base(id ?? Guid.CreateVersion7())
    {
        UserId = userId;
        SubmissionId = submissionId;
        Url = url;  
    }
}