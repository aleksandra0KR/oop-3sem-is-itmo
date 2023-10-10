namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class Engine
{
        public abstract int Speed { get; protected set; }
        public abstract TypesOfEngines TypeOfIEngine { get; }
        public abstract int FuelForActivation { get; }
        public abstract int CountFuelConsumption(int distance);
}