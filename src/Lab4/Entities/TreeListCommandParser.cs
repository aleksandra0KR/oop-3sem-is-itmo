using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class TreeListCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "tree" || args[1] != "list") return base.Handle(args);
        if (args.Count != 4) throw new ValueException("Not enough parameters");

        MoodParser moodParser = new LocalMod();
        moodParser.SetNextHandler(new LocalMod());
        Command? command = moodParser.Handle(args);
        return command;
    }
}