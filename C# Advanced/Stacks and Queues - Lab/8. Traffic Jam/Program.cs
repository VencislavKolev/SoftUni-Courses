using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command;
            int totalCarsPassed = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (cars.Any())
                        {
                            totalCarsPassed++;
                            string currCar = cars.Dequeue();
                            Console.WriteLine($"{currCar} passed!");
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
