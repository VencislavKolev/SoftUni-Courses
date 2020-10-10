using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int row = 1; row <= number; row++)
            {
                //започваме печатането от първата колона
                //сегашната стойност на row е от for цикъла
                PrintFugure(1, row);
            }
            for (int row = number - 1; row >= 1; row--)
            {
                PrintFugure(1, row);
            }
        }
        static void PrintFugure(int start, int end)
        {
            //печатаме толкова колони колкото са редовете в момента
            for (int col = start; col <= end; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}
