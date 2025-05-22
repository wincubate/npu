namespace Npu.Application.Common.Time;

public interface IDateTimeOffsetProvider
{
    DateTime UtcNow { get; }
}
