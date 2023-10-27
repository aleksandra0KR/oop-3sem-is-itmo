using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class BIOSRepo
{
    private static BIOSRepo? _instance;
    private BIOSRepo()
    {
        BiosList.Add(new BIOS("AMI", 3, new Collection<string> { "Intel Celeron G5905 OEM" }));
        BiosList.Add(new BIOS("MrBIOS", 2, new Collection<string> { "Intel Celeron G5905 OEM" }));
    }

    public static BIOSRepo Instance => _instance ??= new BIOSRepo();

    public Collection<BIOS> BiosList { get; } = new();

    public void AddNewBIOS(BIOS bios)
    {
        if (bios is null) throw new ValueException("Empty BIOS");
        BiosList.Add(bios);
    }
}