using System;

namespace _01.SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeOneEff = int.Parse(Console.ReadLine());
            int employeeTwoEff = int.Parse(Console.ReadLine());
            int employeeThreeEff = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int hours = 0;
            int helpedPeoplePerHour = employeeOneEff + employeeTwoEff + employeeThreeEff;
            while (studentsCount > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }
                studentsCount -= helpedPeoplePerHour;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
