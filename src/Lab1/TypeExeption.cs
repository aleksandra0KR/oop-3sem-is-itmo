using System;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class TypeExeption : ArgumentException
{
    public TypeExeption(string message, Exception innerException)
        : base(message, innerException) { }

    public TypeExeption(string message)
        : base(message) { }

    public TypeExeption() { }
}