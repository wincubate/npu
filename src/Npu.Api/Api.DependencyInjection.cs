using Npu.Infrastructure.Persistence.Blobs;

namespace Npu.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        services
            .Configure<AzureBlobStorageOptions>(
                configuration.GetSection(nameof(AzureBlobStorageOptions))
            )
            .AddAntiforgery()
            ;

        return services;
    }
}
