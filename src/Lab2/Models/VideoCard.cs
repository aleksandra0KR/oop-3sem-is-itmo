namespace Itmo.ObjectOrientedProgramming.Lab2;

public class VideoCard : IComponent
{
    public VideoCard(Dimensions dimension, int amountOfVideoMemory, int versionOfPcie, int chipFrequency, int powerConsumption)
    {
        Dimension = dimension;
        AmountOfVideoMemory = amountOfVideoMemory;
        VersionOfPCIE = versionOfPcie;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public int ChipFrequency { get; set;  }
    private Dimensions Dimension { get;  }
    private int AmountOfVideoMemory { get;  }
    private int VersionOfPCIE { get; }
    private int PowerConsumption { get;  }
    public IComponent Clone()
    {
        return new VideoCard(Dimension, AmountOfVideoMemory, VersionOfPCIE, ChipFrequency, PowerConsumption);
    }
}