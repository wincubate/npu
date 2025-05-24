using Npu.Application.Common.Security.Requests;
using Npu.Domain.Users;

namespace Npu.Application.Votes.Create;

[Authorize(Policies = "NotSelf")]
public record class CreateVoteCommand : IAuthorizableRequest<CreateVoteCommandResult>
{
    public required IdentityId UserId { get; init; }
    public required Guid SubmissionId { get; init; }
    public required int CreativityScore { get; init; }
    public required int UniquenessScore { get; init; }
}
