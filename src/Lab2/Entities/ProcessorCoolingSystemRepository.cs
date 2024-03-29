using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class ProcessorCoolingSystemRepository
{
    private static ProcessorCoolingSystemRepository? _instance;

    private ProcessorCoolingSystemRepository() { }

    public static ProcessorCoolingSystemRepository Instance => _instance ??= new ProcessorCoolingSystemRepository();
    public Collection<ProcessorCoolingSystem> ProcessorCoolingSystemList { get; } = new();

    public void Faker()
    {
        ProcessorCoolingSystemList.Add(new ProcessorCoolingSystem(
            new Dimensions(52, 110),
            new Collection<string>
            {
                "AM2", "AM2+", "AM3", "AM3+", "FM1", "FM2", "FM2+", "LGA 1150", "LGA 1151", "LGA 1151-v2", "LGA 1155",
                "LGA 1156", "LGA 1200",
            },
            1000));
        ProcessorCoolingSystemList.Add(new ProcessorCoolingSystem(
            new Dimensions(52, 110),
            new Collection<string>
            {
                "AM2", "AM2+", "AM3", "AM3+", "FM1", "FM2", "FM2+", "LGA 1150", "LGA 1151", "LGA 1151-v2", "LGA 1155",
                "LGA 1156", "LGA 1200",
            },
            95));
    }

    public void AddNewCoolingSystem(ProcessorCoolingSystem processorCoolingSystem)
    {
        if (processorCoolingSystem is null) throw new ValueException("Empty Cooling System");
        ProcessorCoolingSystemList.Add(processorCoolingSystem);
    }
}