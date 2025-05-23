using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npu.Domain.Votes;

namespace Npu.Infrastructure.Persistence.Votes;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasKey(vote => vote.Id);
        builder.Property(vote => vote.Id)
            .ValueGeneratedNever();

        builder.Property(vote => vote.UserId);

        builder
            .HasIndex(
                nameof(Vote.SubmissionId),
                nameof(Vote.UserId)
            )
            .IsUnique();
    }
}