using MediatR;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Time;
using Npu.Domain.Submissions;

namespace Npu.Application.Submissions.Create;

internal class CreateSubmissionHandler : IRequestHandler<CreateSubmissionCommand, CreateSubmissionCommandResult>
{
    private readonly ISubmissionsRepository _submissionsRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public CreateSubmissionHandler(
        ISubmissionsRepository submissionsRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider
    )
    {
       _submissionsRepository = submissionsRepository;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;   
    }

    public async Task<CreateSubmissionCommandResult> Handle(CreateSubmissionCommand command, CancellationToken cancellationToken)
    {
        Submission submission = new(
            command.UserId,
            command.Title
        );

        await _submissionsRepository.AddAsync(submission, cancellationToken);

        return new()
        {
            SubmissionId = submission.Id,
            UserId = command.UserId,
            CreatedTime = _dateTimeOffsetProvider.UtcNow
        };
    }
}
