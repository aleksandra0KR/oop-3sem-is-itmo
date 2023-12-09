using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class ConsoleModeShow : CommandParserWithParameters
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        State state;

        if (args["-m"] == "local") state = new LocalFileShow(args["address"]);
        else throw new ValueException("unsupported mode");
        Command command = new CommandConnect(state);
        return command;
    }
}