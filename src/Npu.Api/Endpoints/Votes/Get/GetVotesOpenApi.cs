using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Npu.Api.Endpoints.Votes.Get;

internal static class GetVotesOpenApi
{
    public static OpenApiOperation Add(this OpenApiOperation options)
    {
        options.Summary = "Retrieves all votes for a user's specified submission";
        options.Description = """
            [Requires Role = Admin]
            """;
        options.Parameters[0].Example = new OpenApiString("00000000-0000-0000-0000-111111111111");
        options.Parameters[1].Example = new OpenApiString("bd975fec-2fee-4f73-a1b9-a1db8aebaff4");

        return options;
    }
}