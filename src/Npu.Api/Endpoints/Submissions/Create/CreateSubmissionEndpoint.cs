using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Application.Submissions.Create;
using Npu.Contracts.Submissions;
using Npu.Infrastructure.Security.Authorization;

namespace Npu.Api.Endpoints.Submissions.Create;

internal static class CreateSubmissionEndpoint
{
    internal static RouteHandlerBuilder Register(this WebApplication app)
        => app
            .MapPost("users/{userId:guid}/submissions", PostAsync)
            .WithTags(nameof(Submissions))
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi()
            ;

    private async static Task<
        Results<
            Created<CreateSubmissionResponseDto>,
            ValidationProblem,
            UnauthorizedHttpResult,
            ProblemHttpResult
        >
    > PostAsync(
        IHttpContextAccessor httpContextAccessor,
        ISender mediator,
        Guid userId,
        CreateSubmissionRequestDto requestDto,
        CancellationToken cancellationToken
    )
    {
        try
        {
            CreateSubmissionCommand command = requestDto.MapFrom(userId);
            CreateSubmissionCommandResult commandResult = await mediator.Send(command, cancellationToken);
            (string resource, CreateSubmissionResponseDto responseDto) = commandResult.MapTo(httpContextAccessor.HttpContext);

            return TypedResults.Created(resource, responseDto);
        }
        catch (OperationCanceledException exception) when (exception.CancellationToken == cancellationToken)
        {
            throw;
        }
        catch (ValidationException exception)
        {
            return exception.MapTo400();
        }
        catch (AuthorizationException exception)
        {
            return exception.MapTo401();
        }
        catch (Exception exception)
        {
            return exception.MapTo500();
        }
    }
}
