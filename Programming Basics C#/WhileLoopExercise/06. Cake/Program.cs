using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int totalPieces = width * height;
            int takenPieces = 0;
            string input = Console.ReadLine();
            while (input!="STOP")
            {
                int inputAsNumber = int.Parse(input);
                takenPieces += inputAsNumber;

                if (takenPieces>totalPieces)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if(takenPieces>totalPieces)
            {
                Console.WriteLine($"No more cake left! You need {takenPieces-totalPieces} pieces more.");
            }
            else
            {
                Console.WriteLine($"{totalPieces-takenPieces} pieces are left.");
            }
            
        }
    }
}
