using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class WIFIRepository
{
    private static WIFIRepository? _instance;

    private WIFIRepository() { }

    public static WIFIRepository Instance => _instance ??= new WIFIRepository();
    public Collection<WiFI> WiFiLIst { get; } = new();

    public void Faker()
    {
        WiFiLIst.Add(new WiFI(4, 3, true, 50));
    }

    public void AddNewWiFi(WiFI wifi)
    {
        if (wifi is null) throw new ValueException("Empty WiFi");
        WiFiLIst.Add(wifi);
    }
}