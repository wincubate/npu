using MediatR;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Domain.Submissions;

namespace Npu.Application.Submissions.Search;

internal class SearchSubmissionsQueryHandler : IRequestHandler<SearchSubmissionsQuery, SearchSubmissionsQueryResult>
{
    private readonly ISubmissionsRepository _submissionsRepository;

    public SearchSubmissionsQueryHandler(ISubmissionsRepository submissionsRepository)
    {
        _submissionsRepository = submissionsRepository;
    }

    public async Task<SearchSubmissionsQueryResult> Handle(SearchSubmissionsQuery query, CancellationToken cancellationToken)
    {
        Submission[] submissions = await _submissionsRepository.GetAllByItemNameAsync(query.ItemName, cancellationToken);

        return new()
        {
            ItemName = query.ItemName,
            Submissions = submissions
        };
    }
}
