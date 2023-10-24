using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class PowerUnitRepo
{
    private static PowerUnitRepo? _instance;

    private PowerUnitRepo()
    {
        PowerUnitList.Add(new PowerUnit(1000));
        PowerUnitList.Add(new PowerUnit(450));
    }

    public static PowerUnitRepo Instance => _instance ??= new PowerUnitRepo();
    public Collection<PowerUnit> PowerUnitList { get;  } = new();

    public void AddNewPowerUnit(PowerUnit powerUnit)
    {
        if (powerUnit is null) throw new ValueException("Empty Power Unit");
        PowerUnitList.Add(powerUnit);
    }
}