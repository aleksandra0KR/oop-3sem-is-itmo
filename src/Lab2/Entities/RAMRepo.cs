using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class RAMRepo
{
    private static RAMRepo? _instance;

    private RAMRepo()
    {
        RamList.Add(new RandomAccessMemory(4, 2133, 2, false, false, "DIMM", 4, 50));
    }

    public static RAMRepo Instance => _instance ??= new RAMRepo();
    public Collection<RandomAccessMemory> RamList { get; } = new();

    public void AddNewRAM(RandomAccessMemory ram)
    {
        if (ram is null) throw new ValueException("Empty RAM");
        RamList.Add(ram);
    }
}