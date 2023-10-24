namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Hdd : IComponent
{
    public Hdd(int container, int speed, int powerConsumption)
    {
        Container = container;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    private int Container { get; }
    private int Speed { get; }
    private int PowerConsumption { get; }

    public IComponent Clone()
    {
        return new Hdd(Container, Speed, PowerConsumption);
    }
}