using Npu.Application.Common.Interfaces.Time;

namespace Npu.Infrastructure.Time;

internal class DateTimeOffsetProvider : IDateTimeOffsetProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
