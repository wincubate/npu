namespace Npu.Application.Common.Security.Requests;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AuthorizeAttribute : Attribute
{
    public string? Permissions { get; init; }
    public string? Roles { get; init; }
    public string? Policies { get; init; }
}