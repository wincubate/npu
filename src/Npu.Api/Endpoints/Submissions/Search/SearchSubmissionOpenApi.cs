using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Npu.Api.Endpoints.Submissions.Search;

internal static class SearchSubmissionOpenApi
{
    public static OpenApiOperation Add(this OpenApiOperation options)
    {
        options.Summary = "Searches all submissions for a specified (part of) an item name";
        options.Description = """
            [Allows Unauthenticated]
            """;
        options.Parameters[0].Example = new OpenApiString("frog");

        return options;
    }
}