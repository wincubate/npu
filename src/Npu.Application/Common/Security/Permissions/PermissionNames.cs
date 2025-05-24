namespace Npu.Application.Common.Security.Permissions;

public static partial class PermissionNames
{
    public static class Submission
    {
        public const string Create = "create:submission";
        public const string Upload = "upload:submission";
        public const string Get = "get:submission";
        public const string Delete = "delete:submission";
    }

    public static class Vote
    {
        public const string Create = "create:vote";
        public const string Get = "get:vote";
        public const string Delete = "delete:vote";
    }
}
