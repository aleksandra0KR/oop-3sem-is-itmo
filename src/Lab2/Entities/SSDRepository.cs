using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class SSDRepository
{
    private static SSDRepository? _instance;
    private SSDRepository() { }

    public static SSDRepository Instance => _instance ??= new SSDRepository();
    public Collection<SSD> SSDList { get; } = new();

    public void Faker()
    {
        SSDList.Add(new SSD("Sata", 400, 900, 100));
    }

    public void AddNewSSD(SSD ssd)
    {
        if (ssd is null) throw new ValueException("Empty SSD");
        SSDList.Add(ssd);
    }
}