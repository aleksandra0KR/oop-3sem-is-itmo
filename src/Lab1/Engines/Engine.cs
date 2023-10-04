namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class Engine
{
        protected Engine(char type, int speed)
        {
                TypeOfIEngine = type;
                Speed = speed;
        }

        public abstract int Speed { get; protected set; }
        public abstract char TypeOfIEngine { get; protected set; }
        public abstract int FuelForActivation { get; }
        public abstract int CountFuelConsumption(int distance);
}