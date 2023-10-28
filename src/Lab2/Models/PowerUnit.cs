namespace Itmo.ObjectOrientedProgramming.Lab2;

public class PowerUnit : IComponent
{
    public PowerUnit(int maximumLoad)
    {
        MaximumLoad = maximumLoad;
    }

    public int MaximumLoad { get; }

    public IComponent Clone()
    {
        return new PowerUnit(MaximumLoad);
    }
}