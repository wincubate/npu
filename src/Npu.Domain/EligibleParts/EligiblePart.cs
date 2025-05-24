using Npu.Domain.Common;

namespace Npu.Domain.EligibleParts;

public class EligiblePart : Entity
{
    public EligiblePart() : base(Guid.CreateVersion7())
    {
    }

    public required string BrickLinkPartNumber { get; init; }
    public required string Name { get; init; }
}

