using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class ValueException : ArgumentNullException
{
    public ValueException()
    { }

    public ValueException(string message)
        : base(message)
    { }

    public ValueException(string message, int val)
        : base(message)
    {
        Value = val;
    }

    public ValueException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public int Value { get; }
}