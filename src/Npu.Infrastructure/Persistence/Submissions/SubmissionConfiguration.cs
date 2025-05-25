using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npu.Domain.Submissions;
using Npu.Domain.Users;
using Npu.Domain.Votes;

namespace Npu.Infrastructure.Persistence.Submissions;

public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.HasKey(submission => submission.Id);
        builder.HasMany<Vote>();

        builder.Property(submission => submission.Id)
            .ValueGeneratedNever();

        //builder
        //    .HasOne<User>()
        //    .WithMany()
        //    //.HasForeignKey("UserId")
        //    .OnDelete(DeleteBehavior.Cascade)
        //    .IsRequired();

        builder.Property(Submission => Submission.UserId);
    }
}
