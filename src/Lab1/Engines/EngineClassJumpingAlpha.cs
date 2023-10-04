namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassJumpingAlpha : EngineClassJumping
{
    private const int MatterForKm = 10;
    private char _type;
    private int _rangeOfTraver;
    private int _speed;
    public EngineClassJumpingAlpha()
        : base('A', 100, 100) { }

    public override char TypeOfIEngine
    {
        get => _type;
        protected set => _type = 'A';
    }

    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }

    public override int RangeOfTravel
    {
        get => _rangeOfTraver;
        protected set => _rangeOfTraver = 100;
    }

    public override int FuelForActivation => MatterForKm;

    public override int CountFuelConsumption(int distance)
    {
        int neededfuel = (distance / Speed) * MatterForKm;
        return neededfuel;
    }
}