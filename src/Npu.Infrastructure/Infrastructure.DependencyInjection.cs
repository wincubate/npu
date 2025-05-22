﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npu.Infrastructure.Persistence;
using Npu.Infrastructure.Security;
using Npu.Infrastructure.Time;

namespace Npu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services
            .AddPersistence(configuration)
            .AddTime()
            .AddSecurity()
            ;

        return services;
    }
}
