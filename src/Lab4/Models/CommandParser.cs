using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class CommandParser
{
    private CommandParser? NextParser { get; set; }

    public void SetNextHandler(CommandParser? nextparser)
    {
        NextParser = nextparser;
    }

    public virtual Command? Handle(Dictionary<string, string> args)
    {
        return NextParser?.Handle(args);
    }
}