namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassJunpingGamma : EngineClassJumping
{
    private const int MatterForKM = 30;
    private char _type;
    private int _rangeoftraver = int.MaxValue;
    private int _speed;
    public EngineClassJunpingGamma()
        : base('G', 100, int.MaxValue) { }

    public override char TypeOfIEngine
    {
        get => _type;
        protected set => _type = 'G';
    }

    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }

    public override int RangeOfTravel
    {
        get => _rangeoftraver;
        protected set => _rangeoftraver = int.MaxValue;
    }

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