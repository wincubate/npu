using Microsoft.Extensions.DependencyInjection;
using Npu.Infrastructure.Persistence;
using Npu.Infrastructure.Time;

namespace Npu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddPersistence()
            .AddTime()
            ;

        return services;
    }
}
