using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class FoggySpace : Environment
{
    private char _type;

    public FoggySpace(int numberOfChannels, int lenghtOfChannels)
    {
        NumberOfChannels = numberOfChannels;
        LenghtOfChannels = lenghtOfChannels;
        TypeOfEnvironment = 'F';
    }

    public override char TypeOfEnvironment
    {
        get => _type;
        protected set => _type = 'F';
    }

    protected override Collection<char> NeededEngine { get; } = new() { 'A', 'O', 'G' };
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
