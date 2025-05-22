namespace Npu.Infrastructure.Security.Authorization;

public class AuthorizationException(string? message = null, Exception? innerException = null)
    : SecurityException(message, innerException);
