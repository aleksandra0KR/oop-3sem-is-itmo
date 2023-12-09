namespace Itmo.ObjectOrientedProgramming.Lab4;

public abstract class Filesystem
{
    public string? AbsolutePath { get; set; }
    public abstract bool IsConnected();
}