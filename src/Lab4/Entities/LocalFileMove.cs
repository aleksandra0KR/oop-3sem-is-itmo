using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileMove : State
{
    private string _destinationpath;

    public LocalFileMove(string address, string destination)
        : base(address)
    {
        _destinationpath = destination;
    }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected()) throw new ValueException("Empty file system");

        try
        {
            File.Move(Address, _destinationpath);

            if (!File.Exists(Address))
            {
                throw new ValueException("Path is damaged");
            }
        }
        catch (IOException)
        {
            throw new ValueException("Path is damaged");
        }
    }
}