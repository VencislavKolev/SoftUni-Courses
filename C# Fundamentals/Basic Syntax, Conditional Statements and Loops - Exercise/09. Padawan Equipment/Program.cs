using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lighsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double robesFinalSum = robePrice * studentsCount;
            double lighsabersFinalSum =
               (lighsaberPrice * Math.Ceiling(studentsCount * 1.1));
            double freeBelts = Math.Floor(studentsCount / 6.0);
            double beltsFinalSum = beltPrice * (studentsCount - freeBelts);
            double finalSum = robesFinalSum + lighsabersFinalSum + beltsFinalSum;
            if (money >= finalSum)
            {
                Console.WriteLine($"The money is enough - it would cost {finalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {finalSum - money:f2}lv more.");
            }

        }
    }
}
