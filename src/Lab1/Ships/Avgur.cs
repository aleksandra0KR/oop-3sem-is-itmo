using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Avgur : Ship
{
    public Avgur(Engine engineFirst, EngineClassJumping engineSecond, Deflector deflector, CaseAbility caseAbility)
    {
        if (engineFirst == null && engineSecond == null) throw new ValueException(nameof(engineFirst));
        if (engineFirst != null && engineFirst.TypeOfIEngine != 'E')
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        if (engineSecond != null && engineSecond.TypeOfIEngine != 'A')
        {
            throw new TypeExeption("Not the needed type of Jumping Engine");
        }

        EngineFirst = engineFirst;
        EngineSecond = engineSecond;

        if (deflector == null) throw new ValueException(nameof(deflector));
        if (deflector.TypeOfDeflector != '3' && deflector.TypeOfDeflector != 'F' && deflector.TypeOfDeflector != 'N')
        {
            throw new TypeExeption("Not the needed type of Deflector");
        }

        DeflectorOfShip = deflector;
        if (caseAbility == null) throw new ValueException(nameof(caseAbility));
        if (caseAbility.TypeOfCase != '3')
        {
            throw new TypeExeption("Not the needed type of Case");
        }

        CaseOfShip = caseAbility;
    }
}