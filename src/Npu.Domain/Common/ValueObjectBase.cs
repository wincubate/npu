using System.Diagnostics.CodeAnalysis;

namespace Npu.Domain.Common;

public abstract record ValueObjectBase<T>
{
    public static implicit operator T(ValueObjectBase<T> obj) => obj.Value;

    public T Value { get; }

    public ValueObjectBase(T value)
    {
        Value = value;
    }
}