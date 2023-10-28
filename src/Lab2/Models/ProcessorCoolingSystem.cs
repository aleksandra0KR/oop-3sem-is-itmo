using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ProcessorCoolingSystem : IComponent
{
    public ProcessorCoolingSystem(Dimensions dimension, Collection<string> supportedSockets, int tdp)
    {
        Dimension = dimension;
        SupportedSockets = supportedSockets;
        TDP = tdp;
    }

    public int TDP { get; }
    private Dimensions Dimension { get; }
    private Collection<string> SupportedSockets { get; }

    public IComponent Clone()
    {
        return new ProcessorCoolingSystem(Dimension, SupportedSockets, TDP);
    }
}