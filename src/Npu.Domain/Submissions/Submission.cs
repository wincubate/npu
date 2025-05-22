using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Submissions;

public class Submission : Entity
{
    public required Guid UserId { get; init; }
    public required string Title { get; init; }

    private readonly List<Guid> _imageIds = [];

    public Submission()
    {        
    }

    [SetsRequiredMembers]
    public Submission(
        Guid userId,
        string title,
        Guid? id = null
    ) : base(id ?? Guid.CreateVersion7())
    {
        UserId = userId;
        Title = title;  
    }
}
