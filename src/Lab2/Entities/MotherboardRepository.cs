using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class MotherboardRepository
{
    private static MotherboardRepository? _instance;

    private MotherboardRepository() { }

    public static MotherboardRepository Instance => _instance ??= new MotherboardRepository();
    public Collection<Motherboard> MotherboardList { get; } = new();

    public void Faker()
    {
        MotherboardList.Add(new Motherboard("LGA 1200", 16, 4, 3200, 4, 2, "Micro-ATX", 2.0, "AMI"));
    }

    public void AddNewMotherboard(Motherboard motherboard)
    {
        if (motherboard is null) throw new ValueException("Empty Motherboard");
        MotherboardList.Add(motherboard);
    }
}