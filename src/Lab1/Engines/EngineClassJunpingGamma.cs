namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassJunpingGamma : EngineClassJumping
{
    private const int MatterForKM = 30;
    private int _speed = 100;
    private int _rangeoftraver = int.MaxValue;
    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }

    public override int RangeOfTravel => _rangeoftraver;

    public override int FuelForActivation => MatterForKM;

    public override int CountFuelConsumption(int distance)
    {
        int time = 1;
        while (distance > 0)
        {
            distance -= Speed;
            time++;
            Speed *= Speed;
        }

        return time * MatterForKM;
    }
}