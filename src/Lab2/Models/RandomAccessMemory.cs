namespace Itmo.ObjectOrientedProgramming.Lab2;

public class RandomAccessMemory : IComponent
{
    public RandomAccessMemory(int memorySize, int frequency, int voltage, bool xmp, bool axmp, string formFactor, int versionOfDdr, int powerConsumption)
    {
        MemorySize = memorySize;
        Frequency = frequency;
        Voltage = voltage;
        XMP = xmp;
        AXMP = axmp;
        FormFactor = formFactor;
        VersionOfDDR = versionOfDdr;
        PowerConsumption = powerConsumption;
    }

    public int Frequency { get; }

    private int MemorySize { get; }
    private int Voltage { get; }
    private bool XMP { get; }
    private bool AXMP { get; }
    private string FormFactor { get; }
    private int VersionOfDDR { get;  }
    private int PowerConsumption { get; }

    public IComponent Clone()
    {
        return new RandomAccessMemory(MemorySize, Frequency, Voltage, XMP, AXMP, FormFactor, VersionOfDDR, PowerConsumption);
    }
}