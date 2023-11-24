using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileDelete : State
{
    public LocalFileDelete(string address)
        : base(address) { }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected() || Address is null) throw new ValidationException("Empty file System");
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
