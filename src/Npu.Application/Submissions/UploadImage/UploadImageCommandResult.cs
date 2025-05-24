namespace Npu.Application.Submissions.UploadImage;

public record class UploadImageCommandResult
{
    public required Uri ImageUri { get; init; }
    public required DateTimeOffset CreatedTime { get; init; }
}
