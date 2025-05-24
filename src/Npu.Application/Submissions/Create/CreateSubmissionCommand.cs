using Npu.Application.Common.Security.Requests;
using Npu.Domain.Users;

namespace Npu.Application.Submissions.Create;

[Authorize(Policies = "SelfOrAdmin")]
public record class CreateSubmissionCommand : IAuthorizableRequest<CreateSubmissionCommandResult>    
{
    public required IdentityId UserId { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public required string ItemNumber { get; init; }
}
