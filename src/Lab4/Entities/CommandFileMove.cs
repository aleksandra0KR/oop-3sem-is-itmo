using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandFileMove : Command
{
    public CommandFileMove(string adress, string destination)
    {
        Address = adress;
        Destination = destination;
    }

    private string Address { get; }
    private string Destination { get; }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected()) throw new ValueException("Empty file system");

        try
        {
            File.Move(Address, Destination);

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