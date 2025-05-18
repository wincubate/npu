using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Npu.Application.Submissions.Upload;
using Npu.Contracts;
using Npu.Infrastructure.Persistence.Blobs;

namespace Npu.Api.Endpoints.Upload;

internal static class UploadEndpoint
{
    internal static RouteHandlerBuilder RegisterUploadEndpointMappings(this WebApplication app)
        => app
            .MapPost("/upload", PostAsync)
            .Produces(StatusCodes.Status500InternalServerError)
            //.WithOpenApi(GetConnectorOpenApi.Add)
            .WithOpenApi()
            .DisableAntiforgery()
            ;

    private async static Task<
        Results<
            Ok<UploadResponseDto>,
            ValidationProblem
        >
    > PostAsync(
        IFormFile fileBeingUploaded,
        CancellationToken cancellationToken,
        ISender mediator
    )
    {
        try
        {
            await using UploadCommand command = fileBeingUploaded.MapFrom();
            UploadCommandResult commandResult = await mediator.Send(command,cancellationToken);
            UploadResponseDto responseDto = commandResult.MapTo();

            return TypedResults.Ok(responseDto);
        }
        catch (OperationCanceledException)
        {
            // Propagate exception to properly allow client request cancellation
            throw;
        }
        catch (Exception exception)
        {
            //Activity.Current?.AddException(exception);
            //Activity.Current?.SetStatus(ActivityStatusCode.Error);

            //return TypedResults.Json(
            //    exception.MapTo(dateTimeOffsetProvider),
            //    statusCode: StatusCodes.Status500InternalServerError
            //);
            throw;
        }
    }
}