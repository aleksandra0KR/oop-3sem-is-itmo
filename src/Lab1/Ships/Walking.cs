using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Walking : Ship
{
    public Walking(Engine engineFirst, CaseAbility caseAbility)
    {
        if (engineFirst == null) throw new ValueException(nameof(engineFirst));
        if (engineFirst.TypeOfIEngine != TypesOfEngines.EngineC)
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        EngineFirst = engineFirst;
        if (caseAbility == null) throw new ValueException(nameof(caseAbility));
        if (caseAbility.TypeOfCase != TypesOfCases.FirstCase)
        {
            throw new TypeExeption("Not the needed type of Case");
        }

        CaseOfShip = caseAbility;
    }
}