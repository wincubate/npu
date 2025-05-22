namespace Npu.Infrastructure.Security.Authorization;

public class PrincipalException(string? message = null, Exception? innerException = null)
    : SecurityException(message, innerException);
