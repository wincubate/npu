using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Submissions;

public class Submission : Entity
{
    public required Guid UserId { get; init; }    
    public required string Title { get; init; }
    public string? Description { get; init; }
    public Guid? ImageId { get; set; }
    public string? ImageName { get; set; }
    public Uri? ImageUri { get; set; }

    public required Guid PartId { get; set; }

    public Submission() : base(Guid.CreateVersion7())
    {
    }

    [SetsRequiredMembers]
    public Submission(
        Guid userId,
        string title,
        Guid? imageId, 
        string? imageName,
        Guid? id = null
    ) : base(id ?? Guid.CreateVersion7())
    {
        UserId = userId;
        Title = title;
        ImageId = imageId;
        ImageName = imageName;
    }
}
