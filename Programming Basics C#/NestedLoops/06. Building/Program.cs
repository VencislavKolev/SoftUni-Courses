using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int fl = floors; fl >= 1; fl--) //започваме от последния етаж
            {
                for (int room = 0; room < rooms; room++) //започваме от стая 0
                {
                    if (fl == floors) //ако етажа е посления
                    {
                        Console.Write($"L{fl}{room} ");
                    }
                    else if (fl % 2 == 0 && fl != floors) //ако етажа на който сме е ЧЕТЕН и НЕ е последния
                    {
                        Console.Write($"O{fl}{room} ");
                    }
                    else if (fl % 2 != 0 && fl != floors) //ако етажа на който сме е НЕЧЕТЕН и НЕ е последния
                    {
                        Console.Write($"A{fl}{room} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
