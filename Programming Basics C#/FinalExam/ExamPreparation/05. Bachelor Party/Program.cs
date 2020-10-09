using System;

namespace _05._Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int singer = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int moneyFromGroup = 0;
            int totalGuests = 0;
            int totalMoney = 0;
            while (input!="The restaurant is full")
            {
                int inputAsNum = int.Parse(input);
                if (inputAsNum>=5)
                {
                    moneyFromGroup = 70*inputAsNum;
                }
                else
                {
                    moneyFromGroup = 100*inputAsNum;
                }
                totalMoney += moneyFromGroup;
                totalGuests += inputAsNum;
                input = Console.ReadLine();
            }
            if (totalMoney>=singer)
            {
                Console.WriteLine($"You have {totalGuests} guests and {totalMoney-singer} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {totalGuests} guests and {totalMoney} leva income, but no singer.");
            }
        }
    }
}
