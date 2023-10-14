using System;
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

    protected override Collection<Type> NeededEngine { get; } = new() { typeof(EngineClassJumpingAlpha), typeof(EngineClassJumpingOmega), typeof(EngineClassJunpingGamma) };
    private int NumberOfChannels { get; }
    private int LenghtOfChannels { get; }

    public override int CountAmountOfFuel(Ship ship, int distance)
    {
        if (ship is null) throw new ValueException("Ship is null");
        if (ship.EngineSecond is null) throw new ValueException("Engine is null");
        EngineClassJumping engine = ship.EngineSecond;
        int amountOfFuel = 0;
        for (int i = 0; i < NumberOfChannels; i++)
        {
            amountOfFuel += engine.CountFuelConsumption(LenghtOfChannels);
        }

        return amountOfFuel;
    }
}
