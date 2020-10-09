using System;

namespace _04._Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int percentNoPaint = int.Parse(Console.ReadLine());
            double Space = height * width * 4;
            double totalSpace = Math.Ceiling(Space - Space * percentNoPaint / 100);
            string input = Console.ReadLine();
            while (input != "Tired!")
            {
                int inputAsNum = int.Parse(input);
                totalSpace -= inputAsNum;
                if (totalSpace <= 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }
            if (input == "Tired!")
            {
                Console.WriteLine($"{totalSpace} quadratic m left.");
            }
            else if (totalSpace < 0)
            {
                Console.WriteLine($"All walls are painted and you have {Math.Abs(totalSpace)} l paint left!");
            }
            else
            {
                Console.WriteLine($"All walls are painted! Great job, Pesho!");
            }
        }
    }
}
