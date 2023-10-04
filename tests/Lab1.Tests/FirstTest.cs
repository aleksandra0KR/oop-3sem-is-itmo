using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class FirstTest
    {
        [Fact]
        public void LostTest()
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
            Assert.Equal("Loose! You lost your ship", firstRoute.Start());
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
            Assert.Equal("Loose! You lost your ship", secondRoute.Start());
        }
    }