using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class MotherboardRepo
{
    private static MotherboardRepo? _instance;

    private MotherboardRepo()
    {
        MotherboardList.Add(new Motherboard("LGA 1200", 16, 4, 3200, 4, 2, "Micro-ATX", 2.0, "AMI"));
    }

    public static MotherboardRepo Instance => _instance ??= new MotherboardRepo();
    public Collection<Motherboard> MotherboardList { get; } = new();

    public void AddNewMotherboard(Motherboard motherboard)
    {
        if (motherboard is null) throw new ValueException("Empty Motherboard");
        MotherboardList.Add(motherboard);
    }
}