using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandTreeList : Command
{
    private readonly string filename = "file";
    private readonly string cdName = "cd";
    public CommandTreeList(string depth)
    {
        bool success = int.TryParse(depth, out int x);
        if (success)
        {
            Depth = x;
        }
        else
        {
            throw new ValueException("depth is not integer");
        }
    }

    private int Depth { get; }
    public override void Execute(Filesystem fileSystem)
    {
        if (fileSystem?.AbsolutePath != null) PrintList(fileSystem.AbsolutePath, Depth, 0);
    }

    private void PrintList(string path, int depth, int currentDepth)
    {
        if (currentDepth > depth && depth != -1)
        {
            return;
        }

        string[] files = Directory.GetFiles(path);
        string[] directories = Directory.GetDirectories(path);

        foreach (string file in files)
        {
            Console.WriteLine(filename, " ", file);
        }

        foreach (string directory in directories)
        {
            Console.WriteLine(cdName, " ", directory);
            PrintList(directory, depth, currentDepth + 1);
        }
    }
}