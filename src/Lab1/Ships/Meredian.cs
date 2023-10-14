using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meredian : Ship
{
    public Meredian(Engine engineFirst, Deflector deflector, CaseAbility caseAbility)
    {
        if (engineFirst is null) throw new ValueException(nameof(engineFirst));
        if (engineFirst.GetType() != typeof(EngineClassE))
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        EngineFirst = engineFirst;

        if (deflector is null) throw new ValueException(nameof(deflector));
        if (deflector.GetType() != typeof(DeflectorClass2) && deflector.GetType() != typeof(DeflectorClassFoton) && deflector.GetType() != typeof(DeflectorClassNitrit))
        {
            throw new TypeExeption("Not the needed type of Deflector");
        }

        DeflectorOfShip = deflector;
        if (caseAbility is null) throw new ValueException(nameof(caseAbility));
        if (caseAbility.GetType() != typeof(CaseClass2))
        {
            throw new TypeExeption("Not the needed type of Case");
        }

        CaseOfShip = caseAbility;
    }
}