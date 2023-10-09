using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassE : Engine
{
    private const int FuelForKm = 20;
    private int _speed;
    public EngineClassE()
        : base(100) { }

    public override int FuelForActivation => FuelForKm;

    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }

    public override TypesOfEngines TypeOfIEngine => TypesOfEngines.EngineE;

    public override int CountFuelConsumption(int distance)
    {
        int time = 1;
        while (distance > 0)
        {
            distance -= Speed;
            time++;
            Speed = (int)(Speed * Math.Exp(2 * time));
        }

        return time * FuelForKm;
    }
}