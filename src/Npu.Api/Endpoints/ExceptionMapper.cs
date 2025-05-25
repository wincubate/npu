using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Domain.Exceptions;
using Npu.Infrastructure.Security.Authorization;

namespace Npu.Api.Endpoints;

internal static class ExceptionMapper
{
    public static IStatusCodeHttpResult MapTo(this Exception exception) =>
        exception switch
        {
            ValidationException validationException => validationException.MapTo400(),
            AuthorizationException authorizationException => authorizationException.MapTo401(),
            _ => exception.MapTo500()
        };

    public static ValidationProblem MapTo400(this ValidationException exception)
    {
        Dictionary<string, string[]> errors =
            exception.Errors
                .ToDictionary(
                    error => error.PropertyName,
                    error => new string[] { error.ErrorMessage }
                );

        return TypedResults.ValidationProblem(errors);
    }

    public static UnauthorizedHttpResult MapTo401(this AuthorizationException exception) =>
        TypedResults.Unauthorized();

    public static NotFound<string> MapTo404(this NotFoundException exception) =>
        TypedResults.NotFound(exception.Message);

    public static Conflict<string> MapTo409(this AlreadyExistsException exception) =>
        TypedResults.Conflict<string>(exception.Message);

    public static ProblemHttpResult MapTo500(this Exception exception) =>
        TypedResults.Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            title: exception.Message
        );
}