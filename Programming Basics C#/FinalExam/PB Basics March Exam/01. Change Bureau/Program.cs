using System;

namespace _01._Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoinNumber = int.Parse(Console.ReadLine());
            double chineaseYuanNumber = double.Parse(Console.ReadLine());
            double taxPercentage = double.Parse(Console.ReadLine());

            int bitcoinToLev = 1168;
            double chineaseYuanToUSD = 0.15;
            double USDToLev = 1.76;
            double EURToLev = 1.95;

            double MoneyAfterExchange = (bitcoinNumber * bitcoinToLev + 
                ((chineaseYuanNumber * chineaseYuanToUSD) * USDToLev))/EURToLev;
            double taxValue = MoneyAfterExchange * taxPercentage/100;
            double finalMoney = MoneyAfterExchange - taxValue;
            Console.WriteLine($"Обмененa валута: {finalMoney:f2} EUR");

    
        }
    }
}
