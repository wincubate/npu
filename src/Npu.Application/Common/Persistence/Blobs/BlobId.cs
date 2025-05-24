namespace Npu.Application.Common.Persistence.Blobs;

public readonly record struct BlobId
{
    public static implicit operator Guid(BlobId id) => id.Value;
    public static implicit operator string(BlobId id) => id.Value.ToString();

    public Guid Value { get; }

    public override string ToString() => Value.ToString();

    public BlobId() : this(Guid.CreateVersion7())
    {        
    }

    public BlobId(Guid id)
    {
        Value = id;
    }
}