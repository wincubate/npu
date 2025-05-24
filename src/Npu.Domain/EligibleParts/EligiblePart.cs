using Npu.Domain.Common;

namespace Npu.Domain.EligibleParts;

public class EligiblePart : Entity
{
    public EligiblePart()
    {
    }

    public EligiblePart(Guid id) : base(id)
    {
    }

    public required string BrickLinkPartNumber { get; init; }
    public required string Name { get; init; }
}

