using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npu.Domain.Submissions;

namespace Npu.Infrastructure.Persistence.Submissions;

public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.HasKey(submission => submission.Id);

        builder.Property(submission => submission.Id)
            .ValueGeneratedNever();

        builder.Property(Submission => Submission.UserId);
    }
}
