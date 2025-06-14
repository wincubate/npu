﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Application.Votes.Get;
using Npu.Contracts.Votes.Get;
using Npu.Infrastructure.Security.Authorization;

namespace Npu.Api.Endpoints.Votes.Get;

internal static class GetVotesEndpoint
{
    internal static RouteHandlerBuilder Register(this WebApplication app)
        => app
            .MapGet("users/{userId:guid}/submissions/{submissionId:guid}/votes", GetAsync)
            .WithTags(nameof(Votes))
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi(GetVotesOpenApi.Add)
            ;

    private async static Task<
        Results<
            Ok<GetVotesResponseDto>,
            ValidationProblem,
            UnauthorizedHttpResult,
            ProblemHttpResult
        >
    > GetAsync(
        ISender mediator,
        Guid userId,
        Guid submissionId,
        CancellationToken cancellationToken
    )
    {
        try
        {
            GetVotesQuery query = userId.MapFrom(submissionId);
            GetVotesQueryResult queryResult = await mediator.Send(query, cancellationToken);
            GetVotesResponseDto responseDto = queryResult.MapTo();

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
