using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BIOS : IComponent
{
    public BIOS(string typeOfBios, int version, Collection<string> neededCpu)
    {
        TypeOfBios = typeOfBios;
        Version = version;
        NeededCPU = neededCpu;
    }

    public string TypeOfBios { get;  }
    public Collection<string> NeededCPU { get; }
    private int Version { get; }

    public IComponent Clone()
    {
        return new BIOS(TypeOfBios, Version, NeededCPU);
    }
}