using MediatR;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Persistence.Votes;
using Npu.Application.Common.Time;
using Npu.Domain.Exceptions;
using Npu.Domain.Submissions;
using Npu.Domain.Votes;
using System.Reflection.PortableExecutable;

namespace Npu.Application.Votes.Create;

internal class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommand, CreateVoteCommandResult>
{
    private readonly ISubmissionsRepository _submissionsRepository;
    private readonly IVotesRepository _votesRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public CreateVoteCommandHandler(
        ISubmissionsRepository submissionsRepository,
        IVotesRepository votesRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider
    )
    {
        _submissionsRepository = submissionsRepository;
        _votesRepository = votesRepository;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public async Task<CreateVoteCommandResult> Handle(CreateVoteCommand command, CancellationToken cancellationToken)
    {
        Submission? submission = await _submissionsRepository.GetByIdAsync(command.SubmissionId, cancellationToken);
        if (submission is null || submission?.UserId != command.UserId.Value)
        {
            string message = "Submission not found for user";
            throw new NotFoundException(command.SubmissionId, message);
        }

        if( await _votesRepository.ExistsForUserIdAndSubmissionIdAsync(
            command.UserId,
            command.SubmissionId,
            cancellationToken
        ))
        {
            string message = "Vote for submission already exists for user";
            throw new AlreadyExistsException(command.SubmissionId, message);
        }

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
