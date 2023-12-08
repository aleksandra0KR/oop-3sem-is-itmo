using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileDeleteCommandParser : CommandParser
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args["command"] != "filedelete") return base.Handle(args);
        if (args.Count < 2) throw new ValueException("Not enough parameters");
        Command command = new CommandFileDelete(args["path"]);
        return command;
    }
}