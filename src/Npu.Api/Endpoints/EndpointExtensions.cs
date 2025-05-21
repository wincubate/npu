using Npu.Api.Endpoints.Tokens;
using System.Reflection;

namespace Npu.Api.Endpoints;

internal static class EndpointExtensions
{
    public static WebApplication RegisterEndpointsFromAssembly(this WebApplication application)
    {
        return application.RegisterEndpoints(Assembly.GetExecutingAssembly());
    }

    public static WebApplication RegisterEndpointsFromAssemblyContaining(this WebApplication application, Type type)
    {
        return application.RegisterEndpoints(type.Assembly);
    }

    private static WebApplication RegisterEndpoints(this WebApplication application, Assembly containingAssembly)
    {
        var candidateEndpointsAndMethods = containingAssembly
            .GetTypes()
            .Where(type => IsEndpointClass(type))
            .Select(type => new
            {
                Type = type,
                Method = ExtractPotentialRegisterMethod(type)
            })
            .Where(pair => IsModuleEndpointRegisterMethod(pair.Method))
            .Select(pair => new
            {
                pair.Type,
                Method = pair.Method!
            })
            ;

        foreach (var endpointAndMethod in candidateEndpointsAndMethods)
        {
            _ = InvokeEndpointRegisterMethod(endpointAndMethod.Method, application);
        }

        return application;
    }

    private static bool IsEndpointClass(this Type type) =>
        type.Name.EndsWith("Endpoint") &&
        type.IsAbstract && type.IsSealed; // abstract + sealed in IL == static class

    private static MethodInfo? ExtractPotentialRegisterMethod(this Type type) =>
        type.GetMethod(nameof(GenerateTokenEndpoint.Register),
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic);

    private static bool IsModuleEndpointRegisterMethod(this MethodInfo? potentialMethodInfo)
    {
        return potentialMethodInfo is MethodInfo methodInfo &&
            methodInfo.GetParameters() is [var inputParameterInfo] && inputParameterInfo.ParameterType == typeof(WebApplication) &&
            methodInfo.ReturnParameter.ParameterType == typeof(RouteHandlerBuilder);
    }

    private static RouteHandlerBuilder InvokeEndpointRegisterMethod(this MethodInfo endpointRegisterMethod, WebApplication app)
    {
        return (RouteHandlerBuilder)endpointRegisterMethod.Invoke(null, [app])!;
    }
}
