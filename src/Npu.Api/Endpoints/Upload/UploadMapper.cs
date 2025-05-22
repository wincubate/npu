using Npu.Application.Common.Persistence.Blobs;
using Npu.Application.Submissions.Upload;
using Npu.Contracts;

namespace Npu.Api.Endpoints.Upload;

internal static class UploadMapper
{
    public static UploadCommand MapFrom(this IFormFile file)
        => new()
        {
            Blob = new Blob
            {
                Name = file.FileName,
                Stream = file.OpenReadStream()
            }
        };

    public static UploadResponseDto MapTo(this UploadCommandResult commandResult) =>
        new()
        {
            Id = Guid.CreateVersion7().ToString(),
            CreatedTime = commandResult.CreatedTime
        };
}
