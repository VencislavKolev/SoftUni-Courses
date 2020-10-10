using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeOne = int.Parse(Console.ReadLine());
            int employeeTwo = int.Parse(Console.ReadLine());
            int employeeThree = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int hours = 0;
            int helpedPeoplePerHour = employeeOne + employeeTwo + employeeThree;
            while (peopleCount > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }
                peopleCount -= helpedPeoplePerHour;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
