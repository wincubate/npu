namespace Npu.Application.Submissions.Upload;

public record class UploadCommandResult
{
    public required DateTimeOffset CreatedTime { get; init; }
}
