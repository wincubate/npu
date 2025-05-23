using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Api.Endpoints;
using Npu.Application.Submissions.Create;
using Npu.Application.Tokens.Generate;
using Npu.Contracts.Submissions;
using Npu.Contracts.Tokens;
using Npu.Infrastructure.Security.Authorization;
using System.Threading;

namespace Npu.Api.Endpoints.Submissions;

internal static class CreateSubmissionEndpoint
{
    internal static RouteHandlerBuilder Register(this WebApplication app)
        => app
            .MapPost("/submissions/create", PostAsync)
            .WithTags(nameof(Submissions))
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
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
        ISender mediator,
        CreateSubmissionRequestDto requestDto,
        CancellationToken cancellationToken
    )
    {
        try
        {
            CreateSubmissionCommand command = requestDto.MapFrom();
            CreateSubmissionCommandResult commandResult = await mediator.Send(command, cancellationToken);
            CreateSubmissionResponseDto responseDto = commandResult.MapTo();

            string resource = "https://localhost:7044/submission/xyz";

            return TypedResults.Created(resource, responseDto);

            //CreateSubmissionResponseDto responseDto = new()
            //{
            //    Id = "xyz",
            //    CreatedTime = DateTimeOffset.Now
            //};
            //return TypedResults.Created(resource, responseDto);
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
