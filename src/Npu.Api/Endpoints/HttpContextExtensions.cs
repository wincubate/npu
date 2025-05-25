namespace Npu.Api.Endpoints;

internal static class HttpContextExtensions
{
    private const string HOST = "https://localhost:7044";

    public static string GetRequestHost(this HttpContext? httpContext) =>
        httpContext is not null
            ? $"{httpContext.Request.Scheme}://{httpContext.Request.Host}"
            : HOST
            ;

    public static string GetRequestHostAndPath(this HttpContext? httpContext) =>
        httpContext is not null
            ? $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}"
            : HOST
            ;
}