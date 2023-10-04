namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class EngineClassJumping : Engine
{
    protected EngineClassJumping(char type, int speed, int rangeOfTravel)
        : base(type, speed)
    {
        RangeOfTravel = rangeOfTravel;
    }

    public abstract int RangeOfTravel { get; protected set; }
}