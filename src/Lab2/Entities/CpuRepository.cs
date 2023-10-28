using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class CpuRepository
{
    private static CpuRepository? _instance;
    private CpuRepository() { }

    public static CpuRepository Instance => _instance ??= new CpuRepository();
    public Collection<Cpu> CpuList { get; } = new();

    public void Faker()
    {
        CpuList.Add(new Cpu("Intel Celeron G5905 OEM", 3.5, 2, "LGA 1200", true, 2000, 58, 50));
        CpuList.Add(new Cpu("Intel Celeron G5905 OEM", 3.5, 2, "LGA 1200", true, 2000, 189, 550));
    }

    public void AddNewCPU(Cpu cpu)
    {
        if (cpu is null) throw new ValueException("Empty CPU");
        CpuList.Add(cpu);
    }
}