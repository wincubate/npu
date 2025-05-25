namespace Npu.Domain.Submissions;

public record class SubmissionImage
{
    public required Guid Id { get; init; }
    public required Uri Uri { get; init; }
    public required string Name { get; init; }
}
