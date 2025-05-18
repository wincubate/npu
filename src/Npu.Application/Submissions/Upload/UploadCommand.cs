using MediatR;
using Npu.Application.Common.Interfaces.Persistence.Blobs;

namespace Npu.Application.Submissions.Upload;

public record class UploadCommand :
    IRequest<UploadCommandResult>,
    IAsyncDisposable
{
    public required Blob Blob { get; init; }

    public ValueTask DisposeAsync()
    {
        return Blob.DisposeAsync();
    }
}
