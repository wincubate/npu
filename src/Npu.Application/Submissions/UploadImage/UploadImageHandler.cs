using MediatR;
using Npu.Application.Common.Persistence.Blobs;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Time;
using Npu.Domain.Exceptions;
using Npu.Domain.Submissions;

namespace Npu.Application.Submissions.UploadImage;

internal class UploadImageHandler : IRequestHandler<UploadImageCommand, UploadImageCommandResult>
{
    private readonly ISubmissionsRepository _submissionsRepository;
    private readonly IBlobRepository _blobRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public UploadImageHandler(
        ISubmissionsRepository submissionsRepository,
        IBlobRepository blobRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider
    )
    {
        _submissionsRepository = submissionsRepository;
        _blobRepository = blobRepository;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public async Task<UploadImageCommandResult> Handle(UploadImageCommand command, CancellationToken cancellationToken)
    {
        Submission? submission = await _submissionsRepository.GetByIdAsync(command.SubmissionId, cancellationToken);
        if (submission is null)
        {
            string message = "Submission not found";
            throw new NotFoundException(command.SubmissionId, message);
        }

        if(submission.ImageId is Guid existingImageId)
        {
            BlobId existingBlobId = new(existingImageId);
            await _blobRepository.RemoveById(existingBlobId, cancellationToken);
        }

        Uri imageUri = await _blobRepository.AddAsync(command.Blob, cancellationToken);

        SubmissionImage image = new()
        {
            Id = command.Blob.Id.Value,
            Name = command.Blob.OriginalFileName,
            Uri = imageUri
        };
        submission.SetImage(image);

        await _submissionsRepository.UpdateAsync(submission, cancellationToken);

        return new()
        {
            ImageUri = imageUri,                        
            CreatedTime = _dateTimeOffsetProvider.UtcNow
        };
    }
}
