using Npu.Domain.Votes;

namespace Npu.Application.Votes.Create;

public record class CreateVoteCommandResult
{
    public required Vote Vote { get; init; }
    public required DateTimeOffset CreatedTime { get; init; }   
}
