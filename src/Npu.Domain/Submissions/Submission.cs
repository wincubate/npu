using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Submissions;

public class Submission : Entity
{
    public required Guid UserId { get; init; }
    public required string Title { get; set; }

    public required Guid PartId { get; set; }

    public Submission()
    {
    }

    [SetsRequiredMembers]
    public Submission(
        Guid userId,
        string title,
        Guid? id = null
    ) : base(id ?? Guid.CreateVersion7())
    {
        UserId = userId;
        Title = title;
    }
}

//public class SubmissionPart : Entity
//{
//    public required Guid SubmissionId { get; init; }
//    public required Submission Submission { get; set; }
//    public required Guid PartId { get; init; }
//    public required Part Part { get; set; }
//}

public class Part : Entity
{
    public required string Number { get; init; }
    public required string Name { get; init; }

    public Part()
    {
    }

    [SetsRequiredMembers]
    public Part(
        string number,
        string name,
        Guid? id = null
    ) : base(id ?? Guid.CreateVersion7())
    {
        Number = number;
        Name = name;
    }
}