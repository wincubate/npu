using Microsoft.Extensions.DependencyInjection;
using Npu.Application.Common.Interfaces.Tokens;
using Npu.Infrastructure.Security.Tokens;

namespace Npu.Infrastructure.Security;

public static class DependencyInjection
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
            ;

        return services;
    }
}
