using Microsoft.OpenApi.Models;
using Npu.Infrastructure.Persistence.Blobs;
using Npu.Infrastructure.Security.Tokens;

namespace Npu.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        services
            .AddHttpContextAccessor()
            .Configure<AzureBlobStorageOptions>(
                configuration.GetSection(nameof(AzureBlobStorageOptions))
            )
            .Configure<JwtSettingsOptions>(
                configuration.GetSection(nameof(JwtSettingsOptions))
            )
            .AddAntiforgery()
            .AddSwaggerSecurity()
            ;

        return services;
    }

    private static IServiceCollection AddSwaggerSecurity(this IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.SupportNonNullableReferenceTypes();
                options.NonNullableReferenceTypesAsRequired();

                OpenApiSecurityScheme jwtSecurityScheme = new()
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    },

                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Insert Bearer token without 'Bearer' prefix"
                };

                options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                OpenApiSecurityRequirement requirement = new()
                {
                    { jwtSecurityScheme, [] }
                };
                options.AddSecurityRequirement(requirement);
            }
        );

        return services;
    }
}
