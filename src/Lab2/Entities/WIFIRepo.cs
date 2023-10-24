using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class WIFIRepo
{
    private static WIFIRepo? _instance;

    private WIFIRepo()
    {
        WiFiLIst.Add(new WiFI(4, 3, true, 50));
    }

    public static WIFIRepo Instance => _instance ??= new WIFIRepo();
    public Collection<WiFI> WiFiLIst { get; } = new();

    public void AddNewWiFi(WiFI wifi)
    {
        if (wifi is null) throw new ValueException("Empty WiFi");
        WiFiLIst.Add(wifi);
    }
}