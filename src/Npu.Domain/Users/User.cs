using Npu.Domain.Common;

namespace Npu.Domain.Users;

public class User : Entity
{
    private readonly List<Guid> _submissionIds = [];

    public User(Guid id)
        : base(id)
    {
    }
}
