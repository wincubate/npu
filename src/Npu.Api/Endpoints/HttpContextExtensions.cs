namespace Npu.Api.Endpoints;

internal static class HttpContextExtensions
{
    public static string GetRequestHostAndPath(this HttpContext? httpContext) =>
        httpContext is not null
            ? $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}"
            : "https://localhost:7044"
            ;
}