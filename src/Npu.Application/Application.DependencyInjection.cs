using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Npu.Application.Common.Validation;

namespace Npu.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining(typeof(DependencyInjection))
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cfg.AddOpenBehavior(typeof(GenericValidationBehaviour<,>));
            })
        ;
        return services;
    }
}
