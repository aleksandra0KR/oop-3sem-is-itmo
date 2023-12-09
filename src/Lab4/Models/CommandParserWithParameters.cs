using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract class CommandParserWithParameters : CommandParser
{
    private CommandParserWithParameters? NextParameters { get; set; }

    public void SetNextParameter(CommandParserWithParameters? nextparser)
    {
        NextParameters = nextparser;
    }

    public virtual Command? HandleParameters(Dictionary<string, string> args)
    {
        return NextParameters?.HandleParameters(args);
    }
}