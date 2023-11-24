namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalTreeGoto : State
{
    public LocalTreeGoto(string address)
        : base(address)
    { }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected()) throw new ValueException("Empty file system");
        if (Address is null) throw new ValueException("Empty path");
        fileSystem.AbsolutePath = Address;
    }
}