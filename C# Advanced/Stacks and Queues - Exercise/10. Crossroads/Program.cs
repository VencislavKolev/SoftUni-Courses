using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightInterval = int.Parse(Console.ReadLine());
            int freeWindowInterval = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command;
            int passedCars = 0;
            string crashedCar = string.Empty;
            int hitIndex = -1;
            bool crash = false;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int currGreenInterval = greenLightInterval;
                    while (currGreenInterval > 0 && cars.Any())
                    {
                        string currCar = cars.Peek();
                        int carLength = currCar.Length;
                        if (carLength <= currGreenInterval)
                        {
                            currGreenInterval -= carLength;
                            cars.Dequeue();
                            passedCars++;
                        }
                        else
                        {
                            int timeleft = currGreenInterval + freeWindowInterval;
                            if (carLength <= timeleft)
                            {
                                cars.Dequeue();
                                passedCars++;
                            }
                            else
                            {
                                crashedCar = currCar;
                                hitIndex = currGreenInterval + freeWindowInterval;
                                crash = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                if (crash)
                {
                    break;
                }
            }
            if (crash)
            {
                Console.WriteLine($"A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[hitIndex]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
