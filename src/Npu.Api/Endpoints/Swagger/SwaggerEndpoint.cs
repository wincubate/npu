namespace Npu.Api.Endpoints.Swagger;

internal static class GetVersionEndpoint
{
    internal static WebApplication RegisterSwaggerEndpoint(this WebApplication app)
    {
        app.MapGet("/", GetSwaggerAsync);

        return app;
    }

    private async static Task GetSwaggerAsync(HttpContext context)
    {
        try
        {
            context.Response.Redirect("/swagger");
        }
        catch (Exception exception)
        {
            await context.Response.WriteAsync(exception.Message);
        }
    }
}