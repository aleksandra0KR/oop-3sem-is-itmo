using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class SSDRepo
{
    private static SSDRepo? _instance;
    private SSDRepo()
    {
        SSDList.Add(new SSD("Sata", 400, 900, 100));
    }

    public static SSDRepo Instance => _instance ??= new SSDRepo();
    public Collection<SSD> SSDList { get; } = new();

    public void AddNewSSD(SSD ssd)
    {
        if (ssd is null) throw new ValueException("Empty SSD");
        SSDList.Add(ssd);
    }
}