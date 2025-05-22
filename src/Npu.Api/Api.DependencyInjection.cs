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
            ;

        return services;
    }
}
