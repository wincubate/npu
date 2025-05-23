using Npu.Application.Common.Security.Requests;
using Npu.Domain.Users;

namespace Npu.Application.Votes.Get;

[Authorize(Roles = "Admin")]
public record class GetVotesQuery : IAuthorizableRequest<GetVotesQueryResult>
{
    public IdentityId UserId { get; init; }
    public required Guid SubmissionId { get; init; }
}

