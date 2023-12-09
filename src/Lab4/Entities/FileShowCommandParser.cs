using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileShowCommandParser : CommandParserWithParameters
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args["command"] != "fileshow") return base.Handle(args);
        if (args.Count < 3) throw new ValueException("Not enough parameters");

        return HandleParameters(args);
    }
}