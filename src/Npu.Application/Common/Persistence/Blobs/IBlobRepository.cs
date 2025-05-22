namespace Npu.Application.Common.Persistence.Blobs;

public interface IBlobRepository
{
    Task AddAsync(Blob blob, CancellationToken cancellationToken);
}
