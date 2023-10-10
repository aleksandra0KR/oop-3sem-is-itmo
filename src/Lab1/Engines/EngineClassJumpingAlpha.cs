namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassJumpingAlpha : EngineClassJumping
{
    private const int MatterForKm = 10;
    private int _rangeOfTraver = 100;
    private int _speed = 100;

    public override TypesOfEngines TypeOfIEngine => TypesOfEngines.EngineAlpha;

    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }

    public override int RangeOfTravel => _rangeOfTraver;

    public override int FuelForActivation => MatterForKm;

    public override int CountFuelConsumption(int distance)
    {
        int neededfuel = (distance / Speed) * MatterForKm;
        return neededfuel;
    }
}