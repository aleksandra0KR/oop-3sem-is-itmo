using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalTreeList : State
{
    private readonly int _depth;
    private readonly string nameforfile = "file";
    private readonly string namefocd = "cd";
    public LocalTreeList(string depth)
        : base(" ")
    {
        bool success = int.TryParse(depth, out int x);
        if (success)
        {
            _depth = x;
        }
        else
        {
            throw new ValueException("depth is not integer");
        }
    }

    public override void Execute(Filesystem fileSystem)
    {
        PrintList(Address, _depth, 0);
    }

    public void PrintList(string path, int depth, int currentDepth)
    {
        if (currentDepth > depth && depth != -1)
        {
            return;
        }

        string[] files = Directory.GetFiles(path);
        string[] directories = Directory.GetDirectories(path);

        foreach (string file in files)
        {
            Console.WriteLine(nameforfile, " ", file);
        }

        foreach (string directory in directories)
        {
            Console.WriteLine(namefocd, " ", directory);
            PrintList(directory, depth, currentDepth + 1);
        }
    }
}