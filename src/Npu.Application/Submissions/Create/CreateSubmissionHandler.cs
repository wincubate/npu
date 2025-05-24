using MediatR;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Persistence.Users;
using Npu.Application.Common.Time;
using Npu.Domain.Exceptions;
using Npu.Domain.Submissions;

namespace Npu.Application.Submissions.Create;

internal class CreateSubmissionHandler : IRequestHandler<CreateSubmissionCommand, CreateSubmissionCommandResult>
{
    private readonly IUsersRepository _usersRepository;
    private readonly ISubmissionsRepository _submissionsRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public CreateSubmissionHandler(
        IUsersRepository usersRepository,
        ISubmissionsRepository submissionsRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider
    )
    {
        _usersRepository = usersRepository;
       _submissionsRepository = submissionsRepository;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;   
    }

    public async Task<CreateSubmissionCommandResult> Handle(CreateSubmissionCommand command, CancellationToken cancellationToken)
    {
        if( await _usersRepository.ExistsAsync(command.UserId, cancellationToken) is false)
        {
            string message = $"User not found";
            throw new NotFoundException(command.UserId, message);
        }

        Submission submission = new()
        {
            UserId = command.UserId,
            Title = command.Title,
            Description = command.Description,
            ImageName = null,
            ImageId = null,
            PartId = Guid.NewGuid(), // TODO: Change!!!
        };

        await _submissionsRepository.AddAsync(submission, cancellationToken);

        return new()
        {
            UserId = command.UserId,
            Submission = submission,
            CreatedTime = _dateTimeOffsetProvider.UtcNow
        };
    }
}
