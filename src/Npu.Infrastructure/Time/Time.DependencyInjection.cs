using Microsoft.Extensions.DependencyInjection;
using Npu.Application.Common.Interfaces.Time;

namespace Npu.Infrastructure.Time;

public static class DependencyInjection
{
    public static IServiceCollection AddTime(this IServiceCollection services)
    {
        services
            .AddTransient<IDateTimeOffsetProvider, DateTimeOffsetProvider>()
            ;

        return services;
    }
}
