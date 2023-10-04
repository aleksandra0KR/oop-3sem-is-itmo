using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class OrdinarySpace : Environment
{
    private char _type;

    public OrdinarySpace()
    {
        TypeOfEnvironment = 'O';
    }

    public override char TypeOfEnvironment
    {
        get => _type;
        protected set => _type = 'O';
    }

    protected override Collection<char> NeededEngine { get; } = new() { 'C', 'E' };

    public override int CountAmountOfFuel(Ship ship, int distance)
    {
        if (ship == null) throw new ValueException("Ship is null");
        if (ship.EngineFirst == null) throw new ValueException("Engine is null");
        Engine engine = ship.EngineFirst;
        return engine.CountFuelConsumption(distance);
    }
}