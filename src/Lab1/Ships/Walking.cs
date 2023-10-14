using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Walking : Ship
{
    public Walking(Engine engineFirst, CaseAbility caseAbility)
    {
        if (engineFirst is null) throw new ValueException(nameof(engineFirst));
        if (engineFirst.GetType() != typeof(EngineClassC))
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        EngineFirst = engineFirst;
        if (caseAbility is null) throw new ValueException(nameof(caseAbility));
        if (caseAbility.GetType() != typeof(CaseClass1))
        {
            throw new TypeExeption("Not the needed type of Case");
        }

        CaseOfShip = caseAbility;
    }
}