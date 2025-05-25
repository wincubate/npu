using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npu.Application.Common.Persistence.Blobs;
using Npu.Application.Common.Persistence.EligibleParts;
using Npu.Application.Common.Persistence.Submissions;
using Npu.Application.Common.Persistence.Users;
using Npu.Application.Common.Persistence.Votes;
using Npu.Infrastructure.Common.Persistence;
using Npu.Infrastructure.Persistence.Blobs;
using Npu.Infrastructure.Persistence.EligibleParts;
using Npu.Infrastructure.Persistence.Submissions;
using Npu.Infrastructure.Persistence.Users;
using Npu.Infrastructure.Persistence.Votes;

namespace Npu.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddDbContext<NpuDbContext>(
                options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")
                    )
            )
            .AddTransient<IUsersRepository, UsersRepository>()
            .AddTransient<ISubmissionsRepository, SubmissionsRepository>()
            .AddTransient<IBlobRepository,AzureBlobRepository>()
            .AddTransient<IVotesRepository, VotesRepository>()
            .AddSingleton<IEligiblePartsRepository, InMemoryEligiblePartsRepository>()
            ;

        return services;
    }
}
