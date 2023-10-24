using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class HDDRepo
{
    private static HDDRepo? _instance;
    private HDDRepo()
    {
        HddList.Add(new Hdd(1, 6, 6));
    }

    public static HDDRepo Instance => _instance ??= new HDDRepo();
    public Collection<Hdd> HddList { get; } = new();

    public void AddNewHDD(Hdd hdd)
    {
        if (hdd is null) throw new ValueException("Empty HDD");
        HddList.Add(hdd);
    }
}