using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int SquareMetersLoze = int.Parse(Console.ReadLine());
            double KgGrapes1SquareM = double.Parse(Console.ReadLine());
            int LitresWineNeeded = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double totalGrapes = SquareMetersLoze * KgGrapes1SquareM;
            double TotalLitersWine = (totalGrapes * 0.4)/2.5;
            double SpareOrNeededLiters = Math.Abs(TotalLitersWine - LitresWineNeeded);

            if (TotalLitersWine>=LitresWineNeeded)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(TotalLitersWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(SpareOrNeededLiters)} liters left -> {Math.Ceiling(SpareOrNeededLiters/workers)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(LitresWineNeeded-TotalLitersWine)} liters wine needed.");
            }

        }
    }
}
