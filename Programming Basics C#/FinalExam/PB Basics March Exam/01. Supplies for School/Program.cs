using System;

namespace _01._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pensNumber = int.Parse(Console.ReadLine());
            int markersNumber = int.Parse(Console.ReadLine());
            double literChemical = double.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double moneyPens = pensNumber * 5.80;
            double moneyMarkers = markersNumber * 7.20;
            double chemicalMoney = literChemical * 1.20;

            double TotalSumBeforeDiscount = moneyMarkers + moneyPens + chemicalMoney;
            double FinalSum = TotalSumBeforeDiscount - (TotalSumBeforeDiscount * discountPercentage/100);
            Console.WriteLine($"{FinalSum:f3}");
        }
    }
}
