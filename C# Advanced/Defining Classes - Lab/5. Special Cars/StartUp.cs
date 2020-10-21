using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<List<Tire>> tireSets = new List<List<Tire>>();
            string tireLine = Console.ReadLine();
            int setIndex = 0;
            while (tireLine != "No more tires")
            {
                tireSets.Add(new List<Tire>());
                tireSets[setIndex] = new List<Tire>();
                string[] tireArgs = tireLine.Split();
                for (int i = 0; i < tireArgs.Length - 1; i += 2)
                {
                    Tire tire = new Tire()
                    {
                        Year = int.Parse(tireArgs[i]),
                        Pressure = double.Parse(tireArgs[i + 1])
                    };
                    tireSets[setIndex].Add(tire);
                }
                setIndex++;
                tireLine = Console.ReadLine();
            }

            string engineLine = Console.ReadLine();
            List<List<Engine>> engineList = new List<List<Engine>>();
            int enginePos = 0;
            while (engineLine != "Engines done")
            {
                engineList.Add(new List<Engine>());
                engineList[enginePos] = new List<Engine>();
                string[] engineArgs = engineLine.Split();
                for (int i = 0; i < engineArgs.Length - 1; i++)
                {
                    int horsePower = int.Parse(engineArgs[i]);
                    double cubicCapacity = double.Parse(engineArgs[i + 1]);
                    Engine engine = new Engine(horsePower, cubicCapacity);
                    engineList[enginePos++].Add(engine);
                }
                engineLine = Console.ReadLine();
            }

            string carLine = Console.ReadLine();
            List<Car> cars = new List<Car>();
            while (carLine != "Show special")
            {
                string[] carArgs = carLine.Split();
                for (int i = 0; i < carArgs.Length / carArgs.Length; i++)
                {
                    string make = carArgs[i];
                    string model = carArgs[i + 1];
                    int year = int.Parse(carArgs[i + 2]);
                    double fuelQuantity = double.Parse(carArgs[i + 3]);
                    double fuelConsumption = double.Parse(carArgs[i + 4]);
                    int engineIndex = int.Parse(carArgs[i + 5]);
                    int tiresIndex = int.Parse(carArgs[i + 6]);

                    Car car = new Car(make, model, year, fuelQuantity, fuelConsumption)
                    {
                        Tires = tireSets[tiresIndex],
                        Engine = engineList[engineIndex][0]
                    };
                    cars.Add(car);
                }
                carLine = Console.ReadLine();
            }
            Func<Car, bool> filter = c => c.Year >= 2017 &&
               c.Engine.HorsePower > 330 &&
               c.Tires.Sum(t => t.Pressure) >= 9 &&
               c.Tires.Sum(t => t.Pressure) <= 10;
            List<Car> specialCars = new List<Car>();
            foreach (Car car in cars
                .Where(filter))
            {
                car.Drive(20);
                specialCars.Add(car);
            }
            Console.WriteLine(string.Join("", specialCars));
        }
    }
}
