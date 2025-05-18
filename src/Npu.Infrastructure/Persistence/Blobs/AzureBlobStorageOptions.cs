namespace Npu.Infrastructure.Persistence.Blobs;

public record class AzureBlobStorageOptions
{
    public required Uri StorageAccountUri { get; init; }
    public required string ContainerName { get; init; }
}
