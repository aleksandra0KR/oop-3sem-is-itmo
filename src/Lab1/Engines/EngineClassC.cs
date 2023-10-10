namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassC : Engine
{
    private const int FuelForKm = 10;
    private int _speed = 100;

    public override int FuelForActivation => FuelForKm;

    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }

    public override TypesOfEngines TypeOfIEngine => TypesOfEngines.EngineC;

    public override int CountFuelConsumption(int distance)
    {
        int neededfuel = distance / Speed * FuelForKm;
        return neededfuel;
    }
}