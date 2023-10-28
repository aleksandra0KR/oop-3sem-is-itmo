using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class CaseRepository
{
    private static CaseRepository? _instance;
    private CaseRepository() { }

    public static CaseRepository Instance => _instance ??= new CaseRepository();
    public Collection<CaseOfComputer> CaseList { get; } = new();

    public void Faker()
    {
        CaseList.Add(new CaseOfComputer(300, 300, new Collection<string> { "Micro-ATX", "Standard-ATX" }, new Dimensions(405, 175)));
    }

    public void AddNewCase(CaseOfComputer caseOfComputer)
    {
        if (caseOfComputer is null) throw new ValueException("Empty Case");
        CaseList.Add(caseOfComputer);
    }
}