using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract class MoodParser
{
    private MoodParser? NextParser { get; set; }

    public void SetNextHandler(MoodParser? nextparser)
    {
        NextParser = nextparser;
    }

    public virtual Command? Handle(Collection<string> args)
    {
        return NextParser?.Handle(args);
    }
}