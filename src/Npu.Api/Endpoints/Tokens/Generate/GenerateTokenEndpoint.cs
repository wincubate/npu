using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Application.Tokens.Generate;
using Npu.Contracts.Tokens.Generate;
using Npu.Infrastructure.Security.Authorization;

namespace Npu.Api.Endpoints.Tokens.Generate;

internal static class GenerateTokenEndpoint
{
    internal static RouteHandlerBuilder Register(this WebApplication app)
        => app
            .MapPost("/tokens/generate", PostAsync)
            .WithTags(nameof(Tokens))
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi()
            ;

    private async static Task<
        Results<
            Ok<GenerateTokenResponseDto>,
            ValidationProblem,
            UnauthorizedHttpResult,
            ProblemHttpResult
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
            GenerateTokenCommandResult commandResult = await mediator.Send(command, cancellationToken);
            GenerateTokenResponseDto responseDto = commandResult.MapTo();

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
