using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalCopyFile : State
{
    private readonly string _destinationpath;

    public LocalCopyFile(string address, string destination)
        : base(address)
    {
        _destinationpath = destination;
    }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected()) throw new ValueException("Empty file system");

        try
        {
            File.Copy(Address, _destinationpath, true);
        }
        catch (IOException)
        {
            throw new ValueException("Path is damaged");
        }
    }
}