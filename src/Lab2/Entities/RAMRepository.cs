using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class RAMRepository
{
    private static RAMRepository? _instance;

    private RAMRepository() { }

    public static RAMRepository Instance => _instance ??= new RAMRepository();
    public Collection<RandomAccessMemory> RamList { get; } = new();

    public void Faker()
    {
        RamList.Add(new RandomAccessMemory(4, 2133, 2, false, false, "DIMM", 4, 50));
    }

    public void AddNewRAM(RandomAccessMemory ram)
    {
        if (ram is null) throw new ValueException("Empty RAM");
        RamList.Add(ram);
    }
}