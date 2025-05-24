using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Npu.Api.Endpoints.Submissions.UploadImage;

internal static class UploadImageOpenApi
{
    public static OpenApiOperation Add(this OpenApiOperation options)
    {
        options.Summary = "Uploads and associates an image to an existing submission";
        options.Parameters[0].Example = new OpenApiString("00000000-0000-0000-0000-111111111111");
        options.Parameters[1].Example = new OpenApiString("bd975fec-2fee-4f73-a1b9-a1db8aebaff4");

        return options;
    }
}

