using Npu.Domain.Submissions;

namespace Npu.Application.Submissions.Search;

public record class SearchSubmissionsQueryResult
{
    public required string ItemName { get; init; }
    public required Submission[] Submissions { get; init; }
}
