using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Npu.Application.Submissions.Search;
using Npu.Contracts.Submissions.Search;

namespace Npu.Api.Endpoints.Submissions.Search;

internal static class SearchSubmissionsEndpoint
{
    internal static RouteHandlerBuilder Register(this WebApplication app)
        => app
            .MapGet("/submissions", GetAsync)
            .WithTags(nameof(Submissions))
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi(SearchSubmissionOpenApi.Add)
            ;

    private async static Task<
        Results<
            Ok<SearchSubmissionsResponseDto>,
            ValidationProblem,
            ProblemHttpResult
        >
    > GetAsync(
        ISender mediator,
        [FromQuery(Name = "itemName")] string itemName,
        CancellationToken cancellationToken
    )
    {
        try
        {
            SearchSubmissionsQuery query = itemName.MapFrom();
            SearchSubmissionsQueryResult queryResult = await mediator.Send(query, cancellationToken);
            SearchSubmissionsResponseDto responseDto = queryResult.MapTo();

            return TypedResults.Ok(responseDto);
        }
        catch (OperationCanceledException exception) when (exception.CancellationToken == cancellationToken)
        {
            throw;
        }
        catch (ValidationException exception)
        {
            return exception.MapTo400();
        }
        catch (Exception exception)
        {
            return exception.MapTo500();
        }
    }
}
