using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int sladkari = int.Parse(Console.ReadLine());
            double cake=double.Parse(Console.ReadLine());
            double gofreta=double.Parse(Console.ReadLine());
            double pancake=double.Parse(Console.ReadLine());

            double priceCake = 45;
            double priceGofreta = 5.8;
            double pricePancake = 3.2;

            double totalOneDay = (cake * priceCake + gofreta * priceGofreta + pancake * pricePancake)*sladkari;
            double totalSum = totalOneDay * days;
            double Expenses = totalSum / 8;
            double SumForCharity = totalSum - Expenses;

            Console.WriteLine($"{SumForCharity:f2}");
        }
    }
}
