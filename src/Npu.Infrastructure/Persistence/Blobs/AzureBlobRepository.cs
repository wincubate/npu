using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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

    public async Task<Uri> AddAsync(Blob blob, CancellationToken cancellationToken)
    {
        BlobServiceClient blobServiceClient = new(
            _options.StorageAccountUri,
            new DefaultAzureCredential()
        );

        BlobContainerClient containerClient =
            blobServiceClient.GetBlobContainerClient(_options.ContainerName);

        string storedFileName = blob.StoredFileName;
        _ = await containerClient.UploadBlobAsync(storedFileName, blob.Stream, cancellationToken);
            
        Uri imageUri = new(
            containerClient.Uri,
            Path.Combine(
                _options.ContainerName,
                storedFileName
            )
        );
        return imageUri;
    }

    public async Task RemoveById(BlobId blobId, CancellationToken cancellationToken)
    {
        BlobServiceClient blobServiceClient = new(
            _options.StorageAccountUri,
            new DefaultAzureCredential()
        );

        BlobContainerClient containerClient =
            blobServiceClient.GetBlobContainerClient(_options.ContainerName);

        _ = await containerClient.DeleteBlobIfExistsAsync(blobId, cancellationToken: cancellationToken);
    }
}