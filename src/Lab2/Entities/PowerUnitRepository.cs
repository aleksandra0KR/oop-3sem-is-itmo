using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class PowerUnitRepository
{
    private static PowerUnitRepository? _instance;

    private PowerUnitRepository() { }

    public static PowerUnitRepository Instance => _instance ??= new PowerUnitRepository();
    public Collection<PowerUnit> PowerUnitList { get;  } = new();

    public void Faker()
    {
        PowerUnitList.Add(new PowerUnit(1000));
        PowerUnitList.Add(new PowerUnit(450));
    }

    public void AddNewPowerUnit(PowerUnit powerUnit)
    {
        if (powerUnit is null) throw new ValueException("Empty Power Unit");
        PowerUnitList.Add(powerUnit);
    }
}