using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class CPURepo
{
    private static CPURepo? _instance;
    private CPURepo()
    {
        CpuList.Add(new CPU("Intel Celeron G5905 OEM", 3.5, 2, "LGA 1200", true, 2000, 58, 50));
        CpuList.Add(new CPU("Intel Celeron G5905 OEM", 3.5, 2, "LGA 1200", true, 2000, 189, 550));
    }

    public static CPURepo Instance => _instance ??= new CPURepo();
    public Collection<CPU> CpuList { get; } = new();

    public void AddNewCPU(CPU cpu)
    {
        if (cpu is null) throw new ValueException("Empty CPU");
        CpuList.Add(cpu);
    }
}