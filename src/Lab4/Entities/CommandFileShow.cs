namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandFileShow : Command
{
    public CommandFileShow(State state)
    {
        State = state ?? throw new ValueException("Empty state");
    }

    private State State { get; set; }

    public override void Execute(Filesystem fileSystem)
    {
        State.Execute(fileSystem);
    }
}