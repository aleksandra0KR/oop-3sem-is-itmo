using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Vaclas : Ship
{
    public Vaclas(Engine engineFirst, EngineClassJumping engineSecond, Deflector deflector, CaseAbility caseAbility)
    {
        if (engineFirst == null && engineSecond == null) throw new ValueException(nameof(engineFirst));
        if (engineFirst != null && engineFirst.TypeOfIEngine != TypesOfEngines.EngineE)
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        if (engineSecond != null && engineSecond.TypeOfIEngine != TypesOfEngines.EngineGamma)
        {
            throw new TypeExeption("Not the needed type of JumpingEngine");
        }

        EngineFirst = engineFirst;
        EngineSecond = engineSecond;

        if (deflector == null) throw new ValueException(nameof(deflector));
        if (deflector.TypeOfDeflector != TypesOfDeflectors.FirstDeflector && deflector.TypeOfDeflector != TypesOfDeflectors.FotonDeflector && deflector.TypeOfDeflector != TypesOfDeflectors.NitritDeflector)
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