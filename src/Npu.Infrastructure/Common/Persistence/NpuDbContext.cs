using Microsoft.EntityFrameworkCore;
using Npu.Domain.Submissions;
using Npu.Domain.Users;

namespace Npu.Infrastructure.Common.Persistence;

public class NpuDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<Image> Images { get; set; }

    public NpuDbContext()
    {
    }
    public NpuDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=.\SQLExpress;Database=Npu;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;")
            .UseSeeding((context, _) =>
            {
                CreateUserIfDoesNotExist(context, Guid.Parse("00000000-0000-0000-0000-111111111111"));
                CreateUserIfDoesNotExist(context, Guid.Parse("00000000-0000-0000-0000-222222222222"));
            });
    }

    private static void CreateUserIfDoesNotExist(DbContext context, Guid newUserId)
    {
        User? newUser = context.Set<User>()
           .FirstOrDefault(user => user.Id == newUserId);
        if (newUser is null)
        {
            context.Set<User>()
               .Add(new User(newUserId));
            context.SaveChanges();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NpuDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
