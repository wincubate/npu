using MediatR;
using Npu.Application.Common.Persistence.EligibleParts;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Persistence.Users;
using Npu.Application.Common.Time;
using Npu.Domain.EligibleParts;
using Npu.Domain.Exceptions;
using Npu.Domain.Submissions;

namespace Npu.Application.Submissions.Create;

internal class CreateSubmissionHandler : IRequestHandler<CreateSubmissionCommand, CreateSubmissionCommandResult>
{
    private readonly IUsersRepository _usersRepository;
    private readonly ISubmissionsRepository _submissionsRepository;
    private readonly IEligiblePartsRepository _eligiblePartsRepository;
    private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

    public CreateSubmissionHandler(
        IUsersRepository usersRepository,
        ISubmissionsRepository submissionsRepository,
        IEligiblePartsRepository eligiblePartsRepository,
        IDateTimeOffsetProvider dateTimeOffsetProvider
    )
    {
        _usersRepository = usersRepository;
        _submissionsRepository = submissionsRepository;
        _eligiblePartsRepository = eligiblePartsRepository;
        _dateTimeOffsetProvider = dateTimeOffsetProvider;
    }

    public async Task<CreateSubmissionCommandResult> Handle(CreateSubmissionCommand command, CancellationToken cancellationToken)
    {
        if (await _usersRepository.ExistsAsync(command.UserId, cancellationToken) is false)
        {
            string message = $"User not found";
            throw new NotFoundException(command.UserId, message);
        }

        EligiblePart? eligiblePart = await _eligiblePartsRepository.GetByItemNumberAsync(command.ItemNumber, cancellationToken);
        if( eligiblePart is null)
        {
            string message = $"Part with item number {command.ItemNumber} not found";
            throw new NotFoundException(null, message);
        }

        Submission submission = new()
        {
            UserId = command.UserId,
            Title = command.Title,
            Description = command.Description,
            ImageName = null,
            ImageId = null,
            PartId = eligiblePart.Id,
            BrickLinkItemNumber = command.ItemNumber,
            PartName = eligiblePart.Name
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
