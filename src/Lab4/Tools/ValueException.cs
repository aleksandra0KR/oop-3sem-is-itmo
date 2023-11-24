using System;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ValueException : ArgumentNullException
{
    public ValueException()
    { }

    public ValueException(string message)
        : base(message + "can't be null")
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