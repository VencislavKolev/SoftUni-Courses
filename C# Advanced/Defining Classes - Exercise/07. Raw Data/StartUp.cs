using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Raw_Data
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Car> cars = new HashSet<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split();
                string model = carArgs[0];
                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);

                int cargoWeigth = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                Engine engine = CreateEngine(engineSpeed, enginePower);
                Cargo cargo = CreateCargo(cargoWeigth, cargoType);
                List<Tire> tires = new List<Tire>();
                GetTires(carArgs, tires);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                HashSet<Car> result = cars
                    .Where(c => c.Cargo.Type == "fragile"
                    && c.Tires.Any(t => t.Pressure < 1))
                    .ToHashSet();
                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
            else if (command == "flamable")
            {
                HashSet<Car> result = cars
                    .Where(c => c.Cargo.Type == "flamable"
                    && c.Engine.Power > 250)
                    .ToHashSet();
                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
        }

        private static void GetTires(string[] carArgs, List<Tire> tires)
        {
            for (int j = 5; j < carArgs.Length; j += 2)
            {
                double tirePressure = double.Parse(carArgs[j]);
                int tireAge = int.Parse(carArgs[j + 1]);
                Tire tire = CreateTire(tirePressure, tireAge);
                tires.Add(tire);
            }
        }

        static Engine CreateEngine(int speed,int power)
        {
            return new Engine(speed, power);
        }
        static Cargo CreateCargo(int weigth,string type)
        {
            return new Cargo(weigth, type);
        }
        static Tire CreateTire(double pressure,int age)
        {
            return new Tire(age, pressure);
        }
    }
}
