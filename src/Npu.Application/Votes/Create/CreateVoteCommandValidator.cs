using FluentValidation;

namespace Npu.Application.Votes.Create;

public class CreateVoteCommandValidator : AbstractValidator<CreateVoteCommand>
{
    public CreateVoteCommandValidator()
    {
        RuleFor(command => command.CreativityScore)
            .InclusiveBetween(1,5)
            ;
        RuleFor(command => command.UniquenessScore)
            .InclusiveBetween(1, 5)
            ;
    }
}