﻿using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Engine engine = null;
                string[] engineArgs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string model = engineArgs[0];
                int power = int.Parse(engineArgs[1]);

                if (engineArgs.Length == 4)
                {
                    int displacement = int.Parse(engineArgs[2]);
                    string efficiency = engineArgs[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (engineArgs.Length == 3)
                {
                    int displacement;
                    bool isDisplacement = int.TryParse(engineArgs[2], out displacement);
                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = engineArgs[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if (engineArgs.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                if (engine != null)
                {
                    engines.Add(engine);
                }
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                Car car = null;
                string[] carArgs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string model = carArgs[0];
                string engineModel = carArgs[1];
                Engine engine = engines.First(e => e.Model == engineModel);

                if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArgs.Length == 3)
                {
                    double weight;
                    bool isWeight = double.TryParse(carArgs[2], out weight);
                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = carArgs[2];
                        car = new Car(model, engine, color);
                    }
                }
                else if (carArgs.Length == 4)
                {
                    double weight = double.Parse(carArgs[2]);
                    string color = carArgs[3];
                    car = new Car(model, engine, weight, color);
                }
                if (car != null)
                {
                    cars.Add(car);
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
