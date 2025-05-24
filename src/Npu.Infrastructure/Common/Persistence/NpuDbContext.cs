using Microsoft.EntityFrameworkCore;
using Npu.Domain.Submissions;
using Npu.Domain.Users;
using Npu.Domain.Votes;

namespace Npu.Infrastructure.Common.Persistence;

public class NpuDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<Vote> Votes { get; set; }

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
                CreateUser(context, Guid.Parse("00000000-0000-0000-0000-111111111111"));
                CreateUser(context, Guid.Parse("00000000-0000-0000-0000-222222222222"));
            })
            ;
            //.UseSeeding((context, _) =>
            // {
            //     CreateParts(context, new Part("x223", "Frog"));
            //     CreateParts(context, new Part("4073", "Plate, Round 1 x 1"));
            // });
    }

    private static void CreateUser(DbContext context, Guid newUserId)
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

    private static void CreateParts(DbContext context, Part part)
    {
        Part? newPart = context.Set<Part>()
           .FirstOrDefault(p => p.Number == part.Number);
        if (newPart is null)
        {
            context.Set<Part>()
               .Add(part);
            context.SaveChanges();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NpuDbContext).Assembly);

        modelBuilder.Entity<Submission>()
            .HasMany<Vote>()
            ;

        //modelBuilder.Entity<Submission>()
        //    .HasMany(submission => submission.Posts)
        //    .WithOne(Submission => e.Blog)
        //    .HasForeignKey(e => e.BlogId)
        //    .HasPrincipalKey(e => e.Id);

        base.OnModelCreating(modelBuilder);
    }
}
