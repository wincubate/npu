namespace Npu.Application.Common.Security.Requests;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AuthorizeAttribute : Attribute
{
    public string? Permission { get; init; }
    public string? Role { get; init; }
    public string? Policy { get; init; }
}