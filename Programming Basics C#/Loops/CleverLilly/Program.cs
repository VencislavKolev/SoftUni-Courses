using System;

namespace CleverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageLilly = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int toyCounter = 0;
            int moneyFromToys = 0;
            int savedMoney = 0;
            int stolenMoney = 0;
            int oldValue = 0;
            int totalSavedMoney = 0;
            
            for (int i = 1; i <= ageLilly; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += 10;
                    oldValue = oldValue + savedMoney;
                    stolenMoney++;
                }
                else
                {
                    toyCounter++;
                }
            }
            moneyFromToys = toyCounter * toyPrice;
            totalSavedMoney = oldValue + moneyFromToys - stolenMoney;
            if (totalSavedMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {totalSavedMoney - washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - totalSavedMoney:f2}");
            }
        }
    }
}
