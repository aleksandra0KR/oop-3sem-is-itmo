using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FourthTest
{
    [Fact]
    public void Test4()
    {
        Environment environment1 = new OrdinarySpace();
        Engine engine1 = new EngineClassC();
        CaseAbility case1 = new CaseClass1();
        Ship ship1 = new Walking(engine1, case1);
        var firstPath = new Collection<KeyValuePair<int, Environment>>
        {
            new(10, environment1),
        };
        var firstShips = new Collection<Ship> { ship1 };
        var firstRoute = new Route(firstPath, firstShips);
        Assert.Equal("We need 10l of fuel and 0 of graviton matter", firstRoute.Start());

        Environment environment2 = new OrdinarySpace();
        Engine engine21 = new EngineClassE();
        EngineClassJumping engine22 = new EngineClassJunpingGamma();
        Deflector deflector2 = new DeflectorClass1();
        CaseAbility case2 = new CaseClass2();
        Ship ship2 = new Vaclas(engine21, engine22, deflector2, case2);
        var secondPath = new Collection<KeyValuePair<int, Environment>>
        {
            new(10, environment2),
        };
        var secondShips = new Collection<Ship> { ship2 };
        var secondRoute = new Route(secondPath, secondShips);
        Assert.Equal("We need 60l of fuel and 30 of graviton matter", secondRoute.Start());
    }
}