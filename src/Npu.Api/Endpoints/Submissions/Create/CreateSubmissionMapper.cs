using Npu.Application.Submissions.Create;
using Npu.Contracts.Submissions;

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
            ItemNumber = requestDto.ItemNumber,
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
            CreatedTime = commandResult.CreatedTime
        };

        return (resource, responseDto);
    }
}
