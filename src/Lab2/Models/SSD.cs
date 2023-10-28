namespace Itmo.ObjectOrientedProgramming.Lab2;

public class SSD : IComponent
{
    public SSD(string typeOfConnection, int container, int speed, int powerConsumption)
    {
        TypeOfConnection = typeOfConnection;
        Container = container;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    private string TypeOfConnection { get; }
    private int Container { get; }
    private int Speed { get; }
    private int PowerConsumption { get; }

    public IComponent Clone()
    {
        return new SSD(TypeOfConnection, Container, Speed, PowerConsumption);
    }
}