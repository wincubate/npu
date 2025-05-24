using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Application.Submissions.UploadImage;
using Npu.Contracts;
using Npu.Infrastructure.Security.Authorization;

namespace Npu.Api.Endpoints.Submissions.UploadImage;

internal static class UploadImageEndpoint
{
    internal static RouteHandlerBuilder Register(this WebApplication app)
        => app
            .MapPost("users/{userId:guid}/submissions/{submissionId:guid}/images", PostAsync)
            .WithTags(nameof(Submissions))
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi()
            .DisableAntiforgery()
            ;

    private async static Task<
        Results<
            Created<UploadImageResponseDto>,
            ValidationProblem,
            UnauthorizedHttpResult,
            ProblemHttpResult
        >
    > PostAsync(
        ISender mediator,
        IFormFile fileBeingUploaded,
        Guid userId,
        Guid submissionId,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await using UploadImageCommand command = fileBeingUploaded.MapFrom(userId, submissionId);
            UploadImageCommandResult commandResult = await mediator.Send(command,cancellationToken);
            UploadImageResponseDto responseDto = commandResult.MapTo();

            return TypedResults.Created(commandResult.ImageUri.ToString(), responseDto);
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
