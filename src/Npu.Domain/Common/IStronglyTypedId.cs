namespace Npu.Domain.Common;

public interface IStronglyTypedId<TId>
{
    TId Value { get; }
}
