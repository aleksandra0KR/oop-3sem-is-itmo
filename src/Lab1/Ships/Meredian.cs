using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meredian : Ship
{
    public Meredian(Engine engineFirst, Deflector deflector, CaseAbility caseAbility)
    {
        if (engineFirst == null) throw new ValueException(nameof(engineFirst));
        if (engineFirst.TypeOfIEngine != TypesOfEngines.EngineE)
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        EngineFirst = engineFirst;

        if (deflector == null) throw new ValueException(nameof(deflector));
        if (deflector.TypeOfDeflector != TypesOfDeflectors.SecondDeflector && deflector.TypeOfDeflector != TypesOfDeflectors.FotonDeflector && deflector.TypeOfDeflector != TypesOfDeflectors.NitritDeflector)
        {
            throw new TypeExeption("Not the needed type of Deflector");
        }

        DeflectorOfShip = deflector;
        if (caseAbility == null) throw new ValueException(nameof(caseAbility));
        if (caseAbility.TypeOfCase != TypesOfCases.SecondCase)
        {
            throw new TypeExeption("Not the needed type of Case");
        }

        CaseOfShip = caseAbility;
    }
}