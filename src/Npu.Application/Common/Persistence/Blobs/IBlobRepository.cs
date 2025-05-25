namespace Npu.Application.Common.Persistence.Blobs;

public interface IBlobRepository
{
    Task<Uri> AddAsync(Blob blob, CancellationToken cancellationToken);
    Task RemoveById(BlobId blobId, CancellationToken cancellationToken);
}
