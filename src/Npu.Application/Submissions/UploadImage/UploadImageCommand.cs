using Npu.Application.Common.Persistence.Blobs;
using Npu.Application.Common.Security.Requests;
using Npu.Application.Common.Security.Permissions;
using Npu.Domain.Users;

namespace Npu.Application.Submissions.UploadImage;

[Authorize(
    Permissions = PermissionNames.Submission.Upload,
    Policies = "SelfOrAdmin")
]
public record class UploadImageCommand :
    IAuthorizableRequest<UploadImageCommandResult>,
    IAsyncDisposable
{
    public required IdentityId UserId { get; init; }
    public required Guid SubmissionId { get; init; }
    public required Blob Blob { get; init; }

    public ValueTask DisposeAsync()
    {
        return Blob.DisposeAsync();
    }

}
