using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileRename : State
{
    private string _destinationpath;

    public LocalFileRename(string address, string destination)
        : base(address)
    {
        if (address is null) throw new ValueException("Damaged path");
        string[] path = address.Split(new char[] { '/' });
        path = path.Except(new string[] { path[^1] }).ToArray();
        foreach (string element in path)
        {
            _destinationpath += element;
        }

        _destinationpath += destination;
    }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected()) throw new ValueException("Empty file system");

        try
        {
            File.Copy(Address, _destinationpath, true);
            File.Delete(Address);

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