using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandFileDelete : Command
{
    public CommandFileDelete(string address)
    {
        Address = address;
    }

    public string Address { get; }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected() || Address is null) throw new ValueException("Empty file System");
        if (File.Exists(Address))
        {
            try
            {
                File.Delete(Address);
            }
            catch (ArgumentException)
            {
                throw new ValueException("Path is damaged");
            }
        }
        else
        {
            throw new ValueException("Path is damaged");
        }
    }
}