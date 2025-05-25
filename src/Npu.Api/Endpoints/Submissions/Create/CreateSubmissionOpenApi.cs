using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Npu.Api.Endpoints.Submissions.Create;

internal static class CreateSubmissionOpenApi
{
    public static OpenApiOperation Add(this OpenApiOperation options)
    {
        options.Summary = "Creates a new submission for a specified user";
        options.Parameters[0].Example = new OpenApiString("00000000-0000-0000-0000-111111111111");

        return options;
    }
}