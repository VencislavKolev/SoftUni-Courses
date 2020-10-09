using System;

namespace ProjectCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Име на архитекта: ");
           string nameArchi=Console.ReadLine();
            Console.Write("Брой проекти:");
            int projects = int.Parse(Console.ReadLine());
            int hours = projects * 3;

            Console.WriteLine($"The architect {nameArchi} will need {hours} hours to complete { projects} project/s.");
        }
    }
}
