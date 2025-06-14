﻿namespace Npu.Domain.Exceptions;

public class AlreadyExistsException(Guid id, string? message, Exception? innerException = null)
    : Exception(message, innerException)
{
    public Guid Id { get; } = id;
}
