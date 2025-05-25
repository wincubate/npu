using MediatR;

namespace Npu.Application.Submissions.Search;

public record class SearchSubmissionsQuery : IRequest<SearchSubmissionsQueryResult>
{
    public required string ItemName { get; init; }
}
