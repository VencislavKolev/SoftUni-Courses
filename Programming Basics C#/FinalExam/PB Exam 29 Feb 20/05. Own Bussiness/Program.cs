using System;

namespace _05._Own_Bussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = width * lenght * height;
            string input = Console.ReadLine();

            while (input!="Done")
            {
                int inputAsNum = int.Parse(input);
                volume -= inputAsNum;
                if (volume<0)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (volume<0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
        }
    }
}
