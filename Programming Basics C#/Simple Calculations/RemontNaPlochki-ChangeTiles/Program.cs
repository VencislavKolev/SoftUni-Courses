using System;

namespace RemontNaPlochki_ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            double N = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double L = double.Parse(Console.ReadLine());
            double M = double.Parse(Console.ReadLine());
            double O = double.Parse(Console.ReadLine());

            double area = N * N;
            double tile = W * L;
            double bench = M * O;
            double timeForOneTile = 0.2;

            double TotalTiles = (area - bench) / tile;
            double timeForAllTiles = TotalTiles * timeForOneTile;
            Console.WriteLine("Брой плочки: " + TotalTiles);
            Console.WriteLine("Нужно време за поставяне на всички плочки: " + timeForAllTiles);

        }
    }
}
