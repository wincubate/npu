using MediatR;

namespace Npu.Application.Votes.Create;

public record class CreateVoteCommand : IRequest<CreateVoteCommandResult>
{
    public required Guid UserId { get; init; }
    public required Guid SubmissionId { get; init; }
    public required int CreativityScore { get; init; }
    public required int UniquenessScore { get; init; }
}
