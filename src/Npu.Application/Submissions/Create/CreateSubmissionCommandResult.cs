namespace Npu.Application.Submissions.Create;

public record class CreateSubmissionCommandResult
{
    public required Guid UserId { get; init; }
    public required Guid SubmissionId { get; init; }
    public required DateTimeOffset CreatedTime { get; init; }
}
