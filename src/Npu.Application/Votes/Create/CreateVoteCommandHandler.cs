using MediatR;
using Npu.Application.Common.Persistence.Votes;
using Npu.Application.Common.Time;
using Npu.Application.Tokens.Generate;
using Npu.Domain.Votes;

namespace Npu.Application.Votes.Create;

internal class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommand, CreateVoteCommandResult>
{
    private readonly IVotesRepository _votesRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public CreateVoteCommandHandler(
        IVotesRepository votesRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider
    )
    {
        _votesRepository = votesRepository;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public async Task<CreateVoteCommandResult> Handle(CreateVoteCommand command, CancellationToken cancellationToken)
    {
        Vote vote = new(
            command.UserId,
            command.SubmissionId,
            command.CreativityScore,
            command.UniquenessScore
        );

        await _votesRepository.AddAsync(vote, cancellationToken);

        return new()
        {
            Vote = vote,
            CreatedTime = _dateTimeOffsetProvider.UtcNow
        };
    }
}
