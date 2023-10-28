namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Cpu : IComponent
{
    public Cpu(string typeOfCpu, double coreFrequency, int numberOfCores, string socket, bool embeddedVideoCore, int maxSupportedMemoryFrequencies, int tdp, int powerConsumption)
    {
        TypeOfCPU = typeOfCpu;
        CoreFrequency = coreFrequency;
        NumberOfCores = numberOfCores;
        Socket = socket;
        EmbeddedVideoCore = embeddedVideoCore;
        MaxSupportedMemoryFrequencies = maxSupportedMemoryFrequencies;
        TDP = tdp;
        PowerConsumption = powerConsumption;
    }

    public string TypeOfCPU { get; }
    public string Socket { get; }
    public bool EmbeddedVideoCore { get; }
    public int MaxSupportedMemoryFrequencies { get; }
    public int TDP { get; }
    public int PowerConsumption { get; }
    private double CoreFrequency { get; }
    private int NumberOfCores { get; }

    public IComponent Clone()
    {
        return new Cpu(TypeOfCPU, CoreFrequency, NumberOfCores, Socket, EmbeddedVideoCore, MaxSupportedMemoryFrequencies, TDP, PowerConsumption);
    }
}