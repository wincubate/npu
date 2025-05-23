using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Application.Votes.Create;
using Npu.Contracts.Votes;
using Npu.Infrastructure.Security.Authorization;

namespace Npu.Api.Endpoints.Votes;

internal static class CreateVotesEndpoint
{
    internal static RouteHandlerBuilder Register(this WebApplication app)
        => app
            .MapPost("/submissions/{submissionId:guid}/votes", PostAsync)
            .WithTags(nameof(Votes))
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi()
            ;

    private async static Task<
        Results<
            Created<CreateVoteResponseDto>,
            ValidationProblem,
            UnauthorizedHttpResult,
            ProblemHttpResult
        >
    > PostAsync(
        ISender mediator,
        Guid submissionId,
        CreateVoteRequestDto requestDto,
        CancellationToken cancellationToken
    )
    {
        try
        {
            CreateVoteCommand command = requestDto.MapFrom(submissionId);
            CreateVoteCommandResult commandResult = await mediator.Send(command, cancellationToken);
            (Uri resource, CreateVoteResponseDto responseDto) = commandResult.MapTo();

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
