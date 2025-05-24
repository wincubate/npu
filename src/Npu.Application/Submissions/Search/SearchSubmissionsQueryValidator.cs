using FluentValidation;

namespace Npu.Application.Submissions.Search;

public class SearchSubmissionsQueryValidator : AbstractValidator<SearchSubmissionsQuery>
{
    public SearchSubmissionsQueryValidator()
    {
        RuleFor(query => query.ItemName)
            .MinimumLength(1)
            .MaximumLength(30)
            ;
    }
}