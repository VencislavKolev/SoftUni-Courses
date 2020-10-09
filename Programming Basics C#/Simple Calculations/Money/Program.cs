using System;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double Yuans = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double bitcoin2EUR = bitcoin * 1168 / 1.95;
            double Yuans2EUR = (Yuans*0.15*1.76)/1.95;
            double totalEUR = bitcoin2EUR + Yuans2EUR;
            double FinalTax = totalEUR * tax/100;
            double FinalSumEUR = totalEUR - FinalTax;

            Console.WriteLine(FinalSumEUR);
        }
    }
}
