namespace Itmo.ObjectOrientedProgramming.Lab2;

public class WiFI : IComponent
{
    public WiFI(int versionOfStandard, int versionOfSpci, bool bluetooth, int powerConsumption)
    {
        VersionOfStandard = versionOfStandard;
        VersionOfSPCI = versionOfSpci;
        Bluetooth = bluetooth;
        PowerConsumption = powerConsumption;
    }

    private int VersionOfStandard { get; }
    private int VersionOfSPCI { get; }
    private bool Bluetooth { get; }
    private int PowerConsumption { get; }

    public IComponent Clone()
    {
        return new WiFI(VersionOfStandard, VersionOfSPCI, Bluetooth, PowerConsumption);
    }
}