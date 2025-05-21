using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Npu.Api.Endpoints;

internal static class ValidationExceptionMapper
{
    public static ValidationProblem MapTo(this ValidationException exception)
    {
        Dictionary<string, string[]> errors =
            exception.Errors
                .ToDictionary(
                    error => error.PropertyName,
                    error => new string[] { error.ErrorMessage }
                );

        return TypedResults.ValidationProblem(errors);
    }

    public static ProblemHttpResult MapTo(this Exception exception) =>
        TypedResults.Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            title: exception.Message
        );
}