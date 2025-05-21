using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Api.Endpoints.Upload;
using Npu.Application.Submissions.Upload;
using Npu.Application.Tokens.Generate;
using Npu.Contracts;
using Npu.Contracts.Tokens;

namespace Npu.Api.Endpoints.Tokens;

internal static class GenerateEndpoint
{
    internal static RouteHandlerBuilder RegisterUploadEndpointMappings(this WebApplication app)
        => app
            .MapPost("/generate", PostAsync)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi()
            ;

    private async static Task<
        Results<
            Ok<GenerateTokenResponseDto>,
            ValidationProblem
        >
    > PostAsync(
        GenerateTokenRequestDto requestDto,
        ISender mediator,
        CancellationToken cancellationToken
    )
    {
        try
        {
            GenerateTokenCommand command = requestDto.MapFrom();
            ErrorOr<GenerateTokenCommandResult> errorOrCommandResult = await mediator.Send(command, cancellationToken);
            return errorOrCommandResult.Match(
                onValue: commandResult => TypedResults.Ok(commandResult.MapTo()),
                onError: error => TypedResults.Problem()
            );
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
