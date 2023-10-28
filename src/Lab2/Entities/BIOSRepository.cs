using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class BIOSRepository
{
    private static BIOSRepository? _instance;
    private BIOSRepository() { }
    public static BIOSRepository Instance => _instance ??= new BIOSRepository();
    public Collection<BIOS> BiosList { get; } = new();
    public void Faker()
    {
        BiosList.Add(new BIOS("AMI", 3, new Collection<string> { "Intel Celeron G5905 OEM" }));
        BiosList.Add(new BIOS("MrBIOS", 2, new Collection<string> { "Intel Celeron G5905 OEM" }));
    }

    public void AddNewBIOS(BIOS bios)
    {
        if (bios is null) throw new ValueException("Empty BIOS");
        BiosList.Add(bios);
    }
}