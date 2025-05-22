namespace Npu.Infrastructure.Security;

public class SecurityException(string? message = null, Exception? innerException = null)
    : Exception(message, innerException);