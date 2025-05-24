using Npu.Application.Submissions.Search;
using Npu.Contracts.Submissions.Search;
using Npu.Domain.Submissions;

namespace Npu.Api.Endpoints.Submissions.Search;

internal static class SearchSubmissionsMapper
{
    public static SearchSubmissionsQuery MapFrom(this string itemName)
        => new()
        {
            ItemName = itemName
        };

    public static SearchSubmissionsResponseDto MapTo(this SearchSubmissionsQueryResult queryResult) =>
        new()
        {
            ItemName = queryResult.ItemName,
            Submissions = [..queryResult.Submissions.Select(MapTo)]
        };

    public static SubmissionResponseDto MapTo(this Submission submission) =>
        new()
        {
            Id = submission.Id,
            UserId = submission.UserId,
            Title = submission.Title,
            Description = submission.Description,
            ImageName = submission.ImageName,
            ImageId = submission.ImageId,
            PartId = submission.PartId,
            BrickLinkItemNumber = submission.BrickLinkItemNumber,
            PartName = submission.PartName            
        };
}
