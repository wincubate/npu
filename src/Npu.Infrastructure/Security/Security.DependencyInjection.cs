using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Npu.Application.Common.Interfaces.Security;
using Npu.Application.Common.Interfaces.Tokens;
using Npu.Infrastructure.Security.Authorization;
using Npu.Infrastructure.Security.Tokens;

namespace Npu.Infrastructure.Security;

public static class DependencyInjection
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            // Tokens
            .AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()

            // Authentication
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer()
            ;
        services
            // Authorization
            .AddTransient<IPrincipalProvider, PrincipalProvider>()
            .AddSingleton<IAuthorizationService, AuthorizationService>()
            .AddSingleton<IPolicyEnforcer, PolicyEnforcer>()
            ;

        return services;
    }
}
