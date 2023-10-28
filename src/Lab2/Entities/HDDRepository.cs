using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class HDDRepository
{
    private static HDDRepository? _instance;
    private HDDRepository() { }

    public static HDDRepository Instance => _instance ??= new HDDRepository();
    public Collection<Hdd> HddList { get; } = new();

    public void Faker()
    {
        HddList.Add(new Hdd(1, 6, 6));
    }

    public void AddNewHDD(Hdd hdd)
    {
        if (hdd is null) throw new ValueException("Empty HDD");
        HddList.Add(hdd);
    }
}