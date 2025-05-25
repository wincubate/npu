namespace Npu.Application.Common.Security.Policies;

public static class PolicyNames
{
    public static readonly PolicyName SelfOrAdmin = new(nameof(SelfOrAdmin));
    public static readonly PolicyName NotSelf = new(nameof(NotSelf));
}
