using Microsoft.Extensions.DependencyInjection;
using Npu.Application.Common.Interfaces.Persistence.Blobs;
using Npu.Infrastructure.Persistence.Blobs;

namespace Npu.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services
            .AddTransient<IBlobRepository,AzureBlobRepository>()
            ;

        return services;
    }
}
