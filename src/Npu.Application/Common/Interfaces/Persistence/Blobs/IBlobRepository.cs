namespace Npu.Application.Common.Interfaces.Persistence.Blobs;

public interface IBlobRepository
{
    Task AddAsync(Blob blob, CancellationToken cancellationToken);
}
