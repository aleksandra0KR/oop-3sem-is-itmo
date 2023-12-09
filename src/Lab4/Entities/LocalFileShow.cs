using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileShow : State
{
    public LocalFileShow(string address)
        : base(address) { }

    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem is null || !fileSystem.IsConnected()) throw new ValueException("Empty file system");

        if (!File.Exists(Address))
        {
            throw new ValueException("Path is damaged");
        }

        var f = new StreamReader(Address);
        while (!f.EndOfStream)
        {
            string? s = f.ReadLine();
            Console.WriteLine(s);
        }

        f.Close();
    }
}