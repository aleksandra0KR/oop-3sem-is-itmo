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
public class Tests
    {
        [Fact]

        // first test
        private void AvgurAndWalkingWillLooseInFoggySpace()
        {
            Environment environment = new FoggySpace(1, 100);
            var firstPath = new Collection<KeyValuePair<int, Environment>>
                {
                    new(500, environment),
                };
            Engine engineFirst = new EngineClassC();
            CaseAbility caseFirst = new CaseClass1();
            Ship firstShip = new Walking(engineFirst, caseFirst);
            var firstShips = new Collection<Ship>() { firstShip };
            var firstRoute = new Route(firstPath, firstShips);
            Assert.Equal("Loose! You lost your ship", firstRoute.Start().StatusOfTheTrip);

            var secondPath = new Collection<KeyValuePair<int, Environment>>
                {
                    new(500, environment),
                };
            Engine engineSecond1 = new EngineClassE();
            EngineClassJumping engineSecond2 = new EngineClassJumpingAlpha();
            CaseAbility caseSecond = new CaseClass3();
            Deflector deflectorSecond = new DeflectorClass3();
            Ship secondShip = new Avgur(engineSecond1, engineSecond2, deflectorSecond, caseSecond);
            var secondShips = new Collection<Ship>() { secondShip };
            var secondRoute = new Route(secondPath, secondShips);
            Assert.Equal("Loose! You lost your ship", secondRoute.Start().StatusOfTheTrip);
        }

        [Fact]

        // second test
        private void ValcasIsDamagedByFlatesVaclasWithFotonDeflectorWin()
        {
            Environment environment3 = new FoggySpace(1, 500);
            Obstacle obstacle3 = new AntimatterFlares(environment3);
            var obstacles3 = new Collection<Obstacle> { obstacle3 };
            environment3.AddObstacles(obstacles3);
            var thirdPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(500, environment3),
            };
            Engine engine3 = new EngineClassE();
            EngineClassJumping engine31 = new EngineClassJunpingGamma();
            CaseAbility case3 = new CaseClass2();
            Deflector deflector3 = new DeflectorClass1();
            Ship ship3 = new Vaclas(engine3, engine31, deflector3, case3);

            var thirdShips = new Collection<Ship>() { ship3 };
            var thirdRoute = new Route(thirdPath, thirdShips);
            Assert.Equal("Dead! Damage is fatale", thirdRoute.Start().StatusOfTheTrip);

            Environment environment4 = new FoggySpace(1, 500);
            Obstacle obstacle4 = new AntimatterFlares(environment4);
            var obstacles4 = new Collection<Obstacle> { obstacle4 };
            environment4.AddObstacles(obstacles4);
            var fourthPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(500, environment4),
            };
            Engine engine4 = new EngineClassE();
            EngineClassJumping engine42 = new EngineClassJunpingGamma();
            CaseAbility case4 = new CaseClass2();
            Deflector deflector4 = new DeflectorClassFoton();
            Ship ship4 = new Vaclas(engine4, engine42, deflector4, case4);

            var fourthShips = new Collection<Ship> { ship4 };
            var fourthRoute = new Route(fourthPath, fourthShips);

            Result res = fourthRoute.Start();
            Assert.Equal("You Win",  res.StatusOfTheTrip);
            Assert.Equal(20,  res.NeededFuel);
            Assert.Equal(120,  res.NeededMatter);
        }

        [Fact]

        // Third test
        private void WhaleKillValcasDemagedCaseOfAvgurMeredianIsAlive()
        {
        Environment environment5 = new NebulaeOfNitrineParticlesSpace();
        Obstacle obstacle5 = new SpaceWhales(environment5);
        var obstacles5 = new Collection<Obstacle> { obstacle5 };
        environment5.AddObstacles(obstacles5);
        Engine engine51 = new EngineClassE();
        EngineClassJumping engine52 = new EngineClassJunpingGamma();
        Deflector deflector5 = new DeflectorClass1();
        CaseAbility case5 = new CaseClass2();
        Ship ship5 = new Vaclas(engine51, engine52, deflector5, case5);

        var fifthPath = new Collection<KeyValuePair<int, Environment>>()
        {
            new(500, environment5),
        };
        var fifthShips = new Collection<Ship> { ship5 };
        var fifthRoute = new Route(fifthPath, fifthShips);
        Assert.Equal("Dead! Damage is fatale", fifthRoute.Start().StatusOfTheTrip);

        Environment environment6 = new NebulaeOfNitrineParticlesSpace();
        Obstacle obstacle6 = new SpaceWhales(environment6);
        var obstacles6 = new Collection<Obstacle>() { obstacle6 };
        environment6.AddObstacles(obstacles6);
        Engine engine61 = new EngineClassE();
        EngineClassJumping engine62 = new EngineClassJumpingAlpha();
        Deflector deflector6 = new DeflectorClass3();
        CaseAbility case6 = new CaseClass3();
        Ship ship6 = new Avgur(engine61, engine62, deflector6, case6);

        var sixthPath = new Collection<KeyValuePair<int, Environment>>()
        {
            new(500, environment6),
        };
        var sixthShips = new Collection<Ship> { ship6 };
        var sixthRoute = new Route(sixthPath, sixthShips);

        sixthRoute.Start();
        if (ship6.DeflectorOfShip != null) Assert.False(ship6.DeflectorOfShip.IsWorking);

        Environment environment7 = new NebulaeOfNitrineParticlesSpace();
        Obstacle obstacle7 = new SpaceWhales(environment7);
        var obstacles7 = new Collection<Obstacle>() { obstacle7 };
        environment7.AddObstacles(obstacles7);
        Engine engine71 = new EngineClassE();
        Deflector deflector7 = new DeflectorClassNitrit();
        CaseAbility case7 = new CaseClass2();
        Ship ship7 = new Meredian(engine71, deflector7, case7);

        var seventhPath = new Collection<KeyValuePair<int, Environment>>()
        {
            new(500, environment7),
        };
        var seventhShips = new Collection<Ship> { ship7 };
        var seventhRoute = new Route(seventhPath, seventhShips);

        Result res = seventhRoute.Start();
        Assert.Equal("You Win",  res.StatusOfTheTrip);
        Assert.Equal(80,  res.NeededFuel);
        Assert.Equal(0,  res.NeededMatter);

        if (ship7.DeflectorOfShip != null) Assert.True(ship7.DeflectorOfShip.IsWorking);
    }

        [Fact]

        // Fourth test
        private void InNormalSpaceWalkingIsMoreProfitableThanVaklas()
        {
            Environment environment8 = new OrdinarySpace();
            Engine engine8 = new EngineClassC();
            CaseAbility case8 = new CaseClass1();
            Ship ship8 = new Walking(engine8, case8);
            var eightPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(10, environment8),
            };
            var eightShips = new Collection<Ship> { ship8 };
            var eightRoute = new Route(eightPath, eightShips);

            Result res = eightRoute.Start();
            Assert.Equal("You Win",  res.StatusOfTheTrip);
            Assert.Equal(10,  res.NeededFuel);
            Assert.Equal(0,  res.NeededMatter);

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

            Result res2 = secondRoute.Start();
            Assert.Equal("You Win",  res2.StatusOfTheTrip);
            Assert.Equal(60,  res2.NeededFuel);
            Assert.Equal(30,  res2.NeededMatter);
        }

        [Fact]

        // Fifth test
        private void InFoggySpaceStellaIsBetterThanAvgur()
        {
            Environment environment1 = new FoggySpace(2, 200);
            Engine engine1 = new EngineClassE();
            EngineClassJumping engine12 = new EngineClassJumpingAlpha();
            Deflector deflector1 = new DeflectorClass3();
            CaseAbility case1 = new CaseClass3();
            Ship ship1 = new Avgur(engine1, engine12, deflector1, case1);
            var firstPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(200, environment1),
            };
            var firstShips = new Collection<Ship> { ship1 };
            var firstRoute = new Route(firstPath, firstShips);
            Assert.Equal("Loose! You lost your ship", firstRoute.Start().StatusOfTheTrip);

            Environment environment2 = new FoggySpace(2, 200);
            Engine engine2 = new EngineClassC();
            EngineClassJumping engine22 = new EngineClassJumpingOmega();
            Deflector deflector2 = new DeflectorClass1();
            CaseAbility case2 = new CaseClass1();
            Ship ship2 = new Stella(engine2, engine22, deflector2, case2);
            var secondPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(200, environment2),
            };
            var secondShips = new Collection<Ship> { ship2 };
            var secondRoute = new Route(secondPath, secondShips);

            Result res = secondRoute.Start();
            Assert.Equal("You Win",  res.StatusOfTheTrip);
            Assert.Equal(10,  res.NeededFuel);
            Assert.Equal(540,  res.NeededMatter);
        }

        [Fact]

        // Sixth test
        private void InNebulaeOfNitrineSpaceValcasIsBetterThanWalking()
        {
            Environment environment1 = new NebulaeOfNitrineParticlesSpace();
            Engine engine1 = new EngineClassC();
            CaseAbility case1 = new CaseClass1();
            Ship ship1 = new Walking(engine1, case1);
            var firstPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(100, environment1),
            };
            var firstShips = new Collection<Ship> { ship1 };
            var firstRoute = new Route(firstPath, firstShips);
            Assert.Equal("Loose! You lost your ship", firstRoute.Start().StatusOfTheTrip);

            Environment environment2 = new NebulaeOfNitrineParticlesSpace();
            Engine engine21 = new EngineClassE();
            EngineClassJumping engine22 = new EngineClassJunpingGamma();
            Deflector deflector2 = new DeflectorClass1();
            CaseAbility case2 = new CaseClass2();
            Ship ship2 = new Vaclas(engine21, engine22, deflector2, case2);
            var secondPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(200, environment2),
            };
            var secondShips = new Collection<Ship>() { ship2 };
            var secondRoute = new Route(secondPath, secondShips);
            Result res = secondRoute.Start();
            Assert.Equal("You Win", res.StatusOfTheTrip);
            Assert.Equal(80, res.NeededFuel);
            Assert.Equal(30, res.NeededMatter);
        }

        [Fact]

        // Seventh test
        private void CheckingRouteWithSeveralPathsAndObstacles()
        {
            Environment environment1 = new OrdinarySpace();
            Obstacle obstacle11 = new Asteroids(environment1);
            Obstacle obstacle12 = new Meteorite(environment1);
            var obstaclesFirstEnvironment = new Collection<Obstacle>() { obstacle11, obstacle12 };
            environment1.AddObstacles(obstaclesFirstEnvironment);
            Environment environment2 = new FoggySpace(2, 200);
            Obstacle obstacle21 = new AntimatterFlares(environment2);
            var obstaclesSecondEnvironment = new Collection<Obstacle> { obstacle21 };
            environment2.AddObstacles(obstaclesSecondEnvironment);
            var firstPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(100, environment1),
                new(400, environment2),
            };
            Engine engine11 = new EngineClassE();
            EngineClassJumping engine12 = new EngineClassJunpingGamma();
            Deflector deflector1 = new DeflectorClassFoton();
            CaseAbility case1 = new CaseClass2();
            Ship ship1 = new Vaclas(engine11, engine12, deflector1, case1);
            var firstShips = new Collection<Ship> { ship1, ship1 };
            var firstRoute = new Route(firstPath, firstShips);

            Result res = firstRoute.Start();
            Assert.Equal("You Win",  res.StatusOfTheTrip);
            Assert.Equal(80,  res.NeededFuel);
            Assert.Equal(210,  res.NeededMatter);
        }
}