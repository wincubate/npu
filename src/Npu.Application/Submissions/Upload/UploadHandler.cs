using MediatR;
using Npu.Application.Common.Persistence.Blobs;
using Npu.Application.Common.Time;

namespace Npu.Application.Submissions.Upload;

internal class UploadHandler : IRequestHandler<UploadCommand, UploadCommandResult>
{
    private readonly IBlobRepository _blobRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public UploadHandler(
        IBlobRepository blobRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider    
    )
    {
        _blobRepository = blobRepository;   
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public async Task<UploadCommandResult> Handle(UploadCommand request, CancellationToken cancellationToken)
    {
        await _blobRepository.AddAsync(request.Blob, cancellationToken);

        return new()
        {
           CreatedTime = _dateTimeOffsetProvider.UtcNow
        };
    }
}
