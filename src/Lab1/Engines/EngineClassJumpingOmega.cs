using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassJumpingOmega : EngineClassJumping
{
    private const int Matterforkm = 20;
    private int _rangeOfTraver = 10000;
    private int _speed = 100;
    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }

    public override int RangeOfTravel => _rangeOfTraver;

    public override int FuelForActivation => Matterforkm;

    public override int CountFuelConsumption(int distance)
    {
        int time = 1;
        while (distance > 0)
        {
            distance -= Speed;
            time++;
            Speed = (int)(time * Math.Log(time));
        }

        return time * Matterforkm;
    }
}