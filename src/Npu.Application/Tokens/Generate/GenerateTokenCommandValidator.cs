using FluentValidation;

namespace Npu.Application.Tokens.Generate;

public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(command => command.FirstName)
            .MinimumLength(1)
            .MaximumLength(20)
            ;
        RuleFor(command => command.LastName)
            .MinimumLength(2)
            .MaximumLength(50)
            ;
        RuleFor(command => command.Email)
            .EmailAddress()
            ;
        RuleForEach(command => command.Permissions)
            .Matches("^([a-z]{1,10}):([a-z]{1,20})$")
            ;
        RuleForEach(command => command.Roles)
            .Matches("^[a-zA-Z]{1,20}$")
            ;
    }
}