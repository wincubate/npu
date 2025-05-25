using Npu.Application.Common.Persistence.Blobs;
using Npu.Application.Submissions.UploadImage;
using Npu.Contracts;

namespace Npu.Api.Endpoints.Submissions.UploadImage;

internal static class UploadImageMapper
{
    public static UploadImageCommand MapFrom(this IFormFile file, Guid userId, Guid submissionId)
        => new()
        {
            UserId = new(userId),
            SubmissionId = submissionId,
            Blob = new Blob
            {
                Id = new(),
                OriginalFileName = file.FileName,
                Stream = file.OpenReadStream()
            }
        };

    public static UploadImageResponseDto MapTo(this UploadImageCommandResult commandResult) =>
        new()
        {
            Id = Guid.CreateVersion7().ToString(),
            Uri = commandResult.ImageUri,
            CreatedTime = commandResult.CreatedTime
        };
}
