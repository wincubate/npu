namespace Npu.Application.Common.Persistence.Blobs;

public record class Blob : IAsyncDisposable
{
    public required string Name { get; init; }
    public required Stream Stream { get; init; }

    public ValueTask DisposeAsync()
    {
        return Stream.DisposeAsync();
    }
}
