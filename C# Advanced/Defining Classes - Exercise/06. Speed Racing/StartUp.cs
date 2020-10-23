using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Car> myCars = new HashSet<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string model = inputArgs[0];
                double fuelAmount = double.Parse(inputArgs[1]);
                double fuelConsumptionPerKilometer = double.Parse(inputArgs[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                myCars.Add(car);
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string carToDrive = cmdArgs[1];
                double distance = double.Parse(cmdArgs[2]);

                Car car = myCars.First(x => x.Model == carToDrive);
                car.Drive(distance);
            }
            Console.WriteLine(string.Join(Environment.NewLine, myCars));
        }
    }
}
