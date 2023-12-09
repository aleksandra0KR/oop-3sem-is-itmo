namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalConnectionState : State
{
    public LocalConnectionState(string address)
        : base(address) { }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null) throw new ValueException("Empty File System");
        if (fileSystem.IsConnected()) throw new ValueException("File System is already connected");
        fileSystem.AbsolutePath = Address;
    }
}