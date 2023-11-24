namespace Itmo.ObjectOrientedProgramming.Lab4;

public abstract class State
{
    protected State(string address)
    {
        Address = address;
    }

    public string Address { get; set; }
    public abstract void Execute(Filesystem fileSystem);
}