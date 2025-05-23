using MediatR;

namespace Npu.Application.Submissions.Create;

public record class CreateSubmissionCommand : IRequest<CreateSubmissionCommandResult>
{
    public required Guid UserId { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public required string[] ItemNumbers { get; init; }
}
