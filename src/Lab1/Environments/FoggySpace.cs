using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class FoggySpace : Environment
{
    public FoggySpace(int numberOfChannels, int lenghtOfChannels)
    {
        NumberOfChannels = numberOfChannels;
        LenghtOfChannels = lenghtOfChannels;
    }

    public override TypesOfEnvironments TypeOfEnvironment => TypesOfEnvironments.FoggySpace;

    protected override Collection<TypesOfEngines> NeededEngine { get; } = new() { TypesOfEngines.EngineAlpha, TypesOfEngines.EngineOmega, TypesOfEngines.EngineGamma };
    private int NumberOfChannels { get; set; }
    private int LenghtOfChannels { get; set; }

    public override int CountAmountOfFuel(Ship ship, int distance)
    {
        if (ship == null) throw new ValueException("Ship is null");
        if (ship.EngineSecond == null) throw new ValueException("Engine is null");
        EngineClassJumping engine = ship.EngineSecond;
        int amountOfFuel = 0;
        for (int i = 0; i < NumberOfChannels; i++)
        {
            amountOfFuel += engine.CountFuelConsumption(LenghtOfChannels);
        }

        return amountOfFuel;
    }
}
