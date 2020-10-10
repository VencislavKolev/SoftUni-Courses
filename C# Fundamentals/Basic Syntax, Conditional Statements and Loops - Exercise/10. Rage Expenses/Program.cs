using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardtPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadsetCounter = 0;
            int trashedMouseCounter = 0;
            int trashedKeyboardCounter = 0;
            int trashedDisplayCounter = 0;

            double totalExpenses = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    trashedHeadsetCounter++;
                }
                if (i % 3 == 0)
                {
                    trashedMouseCounter++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    trashedKeyboardCounter++;
                    if (trashedKeyboardCounter % 2 == 0)
                    {
                        trashedDisplayCounter++;
                    }
                }
            }
            totalExpenses = trashedHeadsetCounter * headsetPrice +
                trashedKeyboardCounter * keyboardtPrice +
                trashedMouseCounter * mousePrice +
                trashedDisplayCounter * displayPrice;

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
