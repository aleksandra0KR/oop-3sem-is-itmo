using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class TreeListCommandParser : CommandParser
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args["command"] != "treelist") return base.Handle(args);
        if (args.Count != 4) throw new ValueException("Not enough parameters");

        Command? command = new CommandTreeList(args["depth"]);
        return command;
    }
}