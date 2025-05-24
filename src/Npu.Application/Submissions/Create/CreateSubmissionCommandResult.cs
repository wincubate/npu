using Npu.Domain.Submissions;

namespace Npu.Application.Submissions.Create;

public record class CreateSubmissionCommandResult
{
    public required Guid UserId { get; init; }
    public required Submission Submission { get; init; }
    public required DateTimeOffset CreatedTime { get; init; }
}
