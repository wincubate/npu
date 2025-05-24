using Npu.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Submissions;

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