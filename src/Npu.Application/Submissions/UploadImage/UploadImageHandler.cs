using MediatR;
using Npu.Application.Common.Persistence.Blobs;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Time;
using Npu.Domain.Exceptions;
using Npu.Domain.Submissions;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Npu.Application.Submissions.UploadImage;

internal class UploadImageHandler : IRequestHandler<UploadImageCommand, UploadImageCommandResult>
{
    private readonly ISubmissionsRepository _submissionRepository;
    private readonly IBlobRepository _blobRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public UploadImageHandler(
        ISubmissionsRepository submissionRepository,
        IBlobRepository blobRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider
    )
    {
        _submissionRepository = submissionRepository;
        _blobRepository = blobRepository;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public async Task<UploadImageCommandResult> Handle(UploadImageCommand command, CancellationToken cancellationToken)
    {
        Submission? submission = await _submissionRepository.GetByIdAsync(command.SubmissionId, cancellationToken);
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

        submission.ImageId = command.Blob.Id.Value;
        submission.ImageName = command.Blob.OriginalFileName;
        submission.ImageUri = imageUri;

        await _submissionRepository.UpdateAsync(submission, cancellationToken);

        return new()
        {
            ImageUri = imageUri,                        
            CreatedTime = _dateTimeOffsetProvider.UtcNow
        };
    }
}
