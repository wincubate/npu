using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using Npu.Application.Common.Persistence.Blobs;

namespace Npu.Infrastructure.Persistence.Blobs;

internal class AzureBlobRepository : IBlobRepository
{
    private readonly AzureBlobStorageOptions _options;

    public AzureBlobRepository(IOptions<AzureBlobStorageOptions> options)
    {
        _options = options.Value;
    }

    public async Task AddAsync(Blob blob, CancellationToken cancellationToken)
    {
        BlobServiceClient blobServiceClient = new(
            _options.StorageAccountUri,
            new DefaultAzureCredential()
        );

        BlobContainerClient containerClient =
            blobServiceClient.GetBlobContainerClient(_options.ContainerName);

        _ = await containerClient.UploadBlobAsync(blob.Name, blob.Stream, cancellationToken);
    }
}