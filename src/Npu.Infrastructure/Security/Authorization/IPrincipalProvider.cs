namespace Npu.Infrastructure.Security.Authorization;

public interface IPrincipalProvider
{
    Principal GetCurrent();
}
