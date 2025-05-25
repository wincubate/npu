namespace Npu.Application.Common.Persistence.Blobs;

public record class Blob : IAsyncDisposable
{
    public required BlobId Id { get; init; }
    public required string OriginalFileName { get; init; }
    public required Stream Stream { get; init; }

    public string StoredFileName => $"{Id}{Path.GetExtension(OriginalFileName)}";

    public ValueTask DisposeAsync()
    {
        return Stream.DisposeAsync();
    }
}
