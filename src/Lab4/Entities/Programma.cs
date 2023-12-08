using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FS;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class Programma
{
    public static ConsoleParser ConsoleParser { get; set; } = new ConsoleParser();
    public CommandParser CommandParser { get; } = ConsoleParser.InitializeParser();
    public Filesystem Filesystem { get; set; } = new LocalFileSystem();
    public SplitForCommand SplitForCommand { get; } = new SplitForCommand();

    public void StartProgramm()
    {
        Filesystem filesystem = new LocalFileSystem();
        while (true)
        {
            string read = Console.ReadLine() ?? throw new ValueException("Empty enter");
            Dictionary<string, string> arguments = SplitForCommand.SplitList(read);
            Command? command = CommandParser.Handle(arguments);
            if (command is null) throw new ValueException("Empty command");
            command.Execute(filesystem);
        }
    }
}