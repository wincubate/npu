using Microsoft.AspNetCore.Http.HttpResults;
using Npu.Contracts;

namespace Npu.Api.Endpoints.Create;

internal static class CreateEndpoint
{
    internal static RouteHandlerBuilder RegisterUploadEndpointMappings(this WebApplication app)
        => app
            .MapPost("/create", PostAsync)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            //.WithOpenApi(GetConnectorOpenApi.Add)
            ;

    private async static Task<
        Results<
            Created<CreateResponseDto>,
            ValidationProblem
        >
    > PostAsync(
        CreateRequestDto requestDto
    )
    {
        try
        {
            // TODO
            await Task.Delay(0);

            string resource = "https://localhost:7044/submission/xyz";
            CreateResponseDto responseDto = new()
            {
                Id = "xyz",
                CreatedTime = DateTimeOffset.Now
            };
            return TypedResults.Created(resource, responseDto);
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