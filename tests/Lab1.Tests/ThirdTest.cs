using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ThirdTest
{
    [Fact]
    public void Test3()
    {
        Environment environment1 = new NebulaeOfNitrineParticlesSpace();
        Obstacle obstacle1 = new SpaceWhales(environment1);
        var obstacles = new Collection<Obstacle> { obstacle1 };
        environment1.AddObstacles(obstacles);
        Engine engine11 = new EngineClassE();
        EngineClassJumping engine12 = new EngineClassJunpingGamma();
        Deflector deflector1 = new DeflectorClass1();
        CaseAbility case1 = new CaseClass2();
        Ship ship1 = new Vaclas(engine11, engine12, deflector1, case1);
        var firstPath = new Collection<KeyValuePair<int, Environment>>()
        {
            new(500, environment1),
        };
        var firstShips = new Collection<Ship> { ship1 };
        var firstRoute = new Route(firstPath, firstShips);
        Assert.Equal("Dead! Damage is fatale", firstRoute.Start());
        Environment environment2 = new NebulaeOfNitrineParticlesSpace();
        Obstacle obstacle2 = new SpaceWhales(environment2);
        var obstacles2 = new Collection<Obstacle>() { obstacle2 };
        environment2.AddObstacles(obstacles2);
        Engine engine21 = new EngineClassE();
        EngineClassJumping engine22 = new EngineClassJumpingAlpha();
        Deflector deflector2 = new DeflectorClass3();
        CaseAbility case2 = new CaseClass3();
        Ship ship2 = new Avgur(engine21, engine22, deflector2, case2);
        var secondPath = new Collection<KeyValuePair<int, Environment>>()
        {
            new(500, environment1),
        };
        var secondShips = new Collection<Ship> { ship2 };
        var secondRoute = new Route(secondPath, secondShips);
        secondRoute.Start();
        if (ship2.DeflectorOfShip != null) Assert.False(ship2.DeflectorOfShip.IsWorking);
        Environment environment3 = new NebulaeOfNitrineParticlesSpace();
        Obstacle obstacle3 = new SpaceWhales(environment3);
        var obstacles3 = new Collection<Obstacle>() { obstacle3 };
        environment3.AddObstacles(obstacles3);
        Engine engine31 = new EngineClassE();
        Deflector deflector3 = new DeflectorClassNitrit();
        CaseAbility case3 = new CaseClass2();
        Ship ship3 = new Meredian(engine31, deflector3, case3);
        var thirdPath = new Collection<KeyValuePair<int, Environment>>()
        {
            new(500, environment1),
        };
        var thirdShips = new Collection<Ship> { ship3 };
        var thirdRoute = new Route(thirdPath, thirdShips);
        Assert.Equal("We need 80l of fuel and 0 of graviton matter", thirdRoute.Start());
        if (ship3.DeflectorOfShip != null) Assert.True(ship3.DeflectorOfShip.IsWorking);
    }
}