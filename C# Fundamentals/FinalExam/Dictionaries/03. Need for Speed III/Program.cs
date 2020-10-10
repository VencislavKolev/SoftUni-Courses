using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, int> carMileage = new Dictionary<string, int>();
            Dictionary<string, int> carFuel = new Dictionary<string, int>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInput = Console.ReadLine().Split("|");
                string car = carInput[0];
                int mileage = int.Parse(carInput[1]);
                int fuel = int.Parse(carInput[2]);
                if (!carMileage.ContainsKey(car))
                {
                    carMileage[car] = mileage;
                    carFuel[car] = fuel;
                }
            }
            int maxTankCapacity = 75;
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] splittedInput = input.Split(" : ");
                string command = splittedInput[0];
                string car = splittedInput[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(splittedInput[2]);
                    int fuelNeeded = int.Parse(splittedInput[3]);
                    bool isEnough = carFuel[car] >= fuelNeeded;
                    if (isEnough)
                    {
                        carMileage[car] += distance;
                        carFuel[car] -= fuelNeeded;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                        if (carMileage[car] >= 100000)
                        {
                            carMileage.Remove(car);
                            carFuel.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }
                    else if (!isEnough)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (command == "Refuel")
                {
                    int litersToRefill = int.Parse(splittedInput[2]);
                    if (carFuel[car] + litersToRefill > maxTankCapacity)
                    {
                        litersToRefill = maxTankCapacity - carFuel[car];
                    }
                    carFuel[car] += litersToRefill;
                    Console.WriteLine($"{car} refueled with {litersToRefill} liters");
                }
                else if (command == "Revert")
                {
                    int kilometersReverted = int.Parse(splittedInput[2]);
                    carMileage[car] -= kilometersReverted;
                    if (carMileage[car] < 10000)
                    {
                        carMileage[car] = 10000;
                        continue;
                    }
                    Console.WriteLine($"{car} mileage decreased by {kilometersReverted} kilometers");
                }
            }
            foreach (var kvp in carMileage.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                string currCar = kvp.Key;
                int mileage = kvp.Value;
                Console.WriteLine($"{currCar} -> Mileage: {mileage} kms, Fuel in the tank: {carFuel[currCar]} lt.");
            }
        }
    }
}
