using Npu.Domain.Common;

namespace Npu.Domain.Submissions;

public class Submission : Entity
{
    public required Guid UserId { get; init; }    
    public required string Title { get; init; }
    public string? Description { get; init; }
    public Guid? ImageId { get; set; }
    public string? ImageName { get; set; }
    public Uri? ImageUri { get; set; }

    public required Guid PartId { get; init; }
    public required string BrickLinkItemNumber { get; init; }
    public required string PartName { get; init; }

    public Submission() : base(Guid.CreateVersion7())
    {
    }
}
