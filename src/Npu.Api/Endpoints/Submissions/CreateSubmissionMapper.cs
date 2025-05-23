using Npu.Application.Submissions.Create;
using Npu.Contracts.Submissions;

namespace Npu.Api.Endpoints.Submissions;

internal static class CreateSubmissionMapper
{
    public static CreateSubmissionCommand MapFrom(this CreateSubmissionRequestDto requestDto)
        => new()
        {
            UserId = requestDto.UserId,
            Title = requestDto.Title,
            Description = requestDto.Description,
            ItemNumbers = requestDto.ItemNumbers,
        };

    public static CreateSubmissionResponseDto MapTo(this CreateSubmissionCommandResult commandResult) =>
        new()
        {
            Id = commandResult.SubmissionId,
            UserId = commandResult.UserId,
            CreatedTime = commandResult.CreatedTime
        };
}
