using Npu.Domain.EligibleParts;

namespace Npu.Application.Common.Persistence.EligibleParts;

public interface IEligiblePartsRepository
{
    Task<EligiblePart?> GetByItemNumberAsync(string itemNumber, CancellationToken cancellationToken);
    Task<EligiblePart[]> GetAllAsync(CancellationToken cancellationToken);
}