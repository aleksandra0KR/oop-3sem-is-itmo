using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileRenameCommandParser : CommandParser
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args["command"] != "filerename") return base.Handle(args);
        if (args.Count < 3) throw new ValueException("Not enough parameters");

        Command command = new CommandFileRename(args["path"], args["destination"]);
        return command;
    }
}