using System;

namespace NPay.Shared.Exceptions;

public abstract class NPayException : Exception
{
    protected NPayException(string message) : base(message)
    {
    }
}