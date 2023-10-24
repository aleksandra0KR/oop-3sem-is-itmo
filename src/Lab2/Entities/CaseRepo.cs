using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class CaseRepo
{
    private static CaseRepo? _instance;
    private CaseRepo()
    {
        CaseList.Add(new CaseOfComputer(300, 300, new Collection<string> { "Micro-ATX", "Standard-ATX" }, new Dimensions(405, 175)));
    }

    public static CaseRepo Instance => _instance ??= new CaseRepo();
    public Collection<CaseOfComputer> CaseList { get; } = new();

    public void AddNewCase(CaseOfComputer caseOfComputer)
    {
        if (caseOfComputer is null) throw new ValueException("Empty Case");
        CaseList.Add(caseOfComputer);
    }
}