using Npu.Application.Common.Persistence.EligibleParts;
using Npu.Domain.EligibleParts;

namespace Npu.Infrastructure.Persistence.EligibleParts;

internal class InMemoryEligiblePartsRepository : IEligiblePartsRepository
{
    private readonly Dictionary<string, EligiblePart> _parts;

    public InMemoryEligiblePartsRepository()
    {
        _parts = new()
        {
            // https://www.bricklink.com/v2/catalog/catalogitem.page?P=x223#T=C (Frog)
            ["x223"] = new EligiblePart()
            {
                BrickLinkPartNumber = "x223",
                Name = "Frog"
            },
            // https://www.bricklink.com/v2/catalog/catalogitem.page?P=4073&idColor=11#T=C&C=11 (Plate, Round 1 x 1)
            ["4073"] = new EligiblePart()
            {
                BrickLinkPartNumber = "4073",
                Name = "Plate, Round 1 x 1"
            }
        };
    }

    public Task<EligiblePart?> GetByItemNumberAsync(string itemNumber, CancellationToken cancellationToken)
    {
        if( _parts.TryGetValue(itemNumber, out EligiblePart? part))
        {
            return Task.FromResult<EligiblePart?>(part);
        }
        return Task.FromResult<EligiblePart?>(null);
    }

    public Task<EligiblePart[]> GetAllAsync(CancellationToken cancellationToken) =>
        Task.FromResult<EligiblePart[]>([.._parts.Values]);
}
