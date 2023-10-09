namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class Engine
{
        protected Engine(int speed)
        {
                Speed = speed;
        }

        public abstract int Speed { get; protected set; }
        public abstract TypesOfEngines TypeOfIEngine { get; }
        public abstract int FuelForActivation { get; }
        public abstract int CountFuelConsumption(int distance);
}