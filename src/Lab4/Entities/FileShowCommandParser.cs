using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileShowCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "file" || args[1] != "show") return base.Handle(args);
        if (args.Count != 5) throw new ValueException("Not enough parameters");
        string adress = args[2];
        string mode = args[4];

        State state;
        if (mode == "local") state = new LocalFileShow(adress);
        else throw new ValueException("unsupported mode");

        Command command = new CommandFileShow(state);
        return command;
    }
}