using Npu.Application.Submissions.Create;
using Npu.Contracts.Submissions.Create;

namespace Npu.Api.Endpoints.Submissions.Create;

internal static class CreateSubmissionMapper
{
    public static CreateSubmissionCommand MapFrom(this CreateSubmissionRequestDto requestDto,
        Guid userId
    )
        => new()
        {
            UserId = new(userId),
            Title = requestDto.Title,
            Description = requestDto.Description,
            ItemNumber = requestDto.BrickLinkItemNumber
        };

    public static (string resource, CreateSubmissionResponseDto responseDto) MapTo(this CreateSubmissionCommandResult commandResult,
            HttpContext? httpContext
        )
    {
        string resource = $"{httpContext.GetRequestHostAndPath}/{commandResult.Submission.Id}";

        CreateSubmissionResponseDto responseDto = new()
        {
            Id = commandResult.Submission.Id,
            UserId = commandResult.UserId,
            Title = commandResult.Submission.Title,
            Description = commandResult.Submission.Description,
            ImageName = commandResult.Submission.ImageName,
            ImageId = commandResult.Submission.ImageId,
            PartId = commandResult.Submission.PartId,
            BrickLinkItemNumber = commandResult.Submission.BrickLinkItemNumber,
            PartName = commandResult.Submission.PartName,
            CreatedTime = commandResult.CreatedTime
        };

        return (resource, responseDto);
    }
}
