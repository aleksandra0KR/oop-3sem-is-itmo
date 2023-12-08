using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandFileCopy : Command
{
    public CommandFileCopy(string destination, string address)
    {
        Destination = destination;
        Address = address;
    }

    private string Address { get; }
    private string Destination { get; }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected()) throw new ValueException("Empty file system");

        try
        {
            File.Copy(Address, Destination, true);
        }
        catch (IOException)
        {
            throw new ValueException("Path is damaged");
        }
    }
}