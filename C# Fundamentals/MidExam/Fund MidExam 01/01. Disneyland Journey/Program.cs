using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int monthsToSaveMoney = int.Parse(Console.ReadLine());
            double savedMoney = 0;
            for (int i = 1; i <= monthsToSaveMoney; i++)
            {
                if (i % 2 != 0 && i != 1)
                {
                    //харчи 16% за дрехи
                    savedMoney *= 0.84;
                }
                else if (i % 4 == 0)
                {
                    //всеки 4ти месец шефа дава 25% бонус от събраните до момента пари 
                    savedMoney *= 1.25;
                }
                //спестява 25% от цената на екскурзията
                savedMoney += journeyCost / 4;
            }
            if (savedMoney >= journeyCost)
            {
                double souvenierMoney = savedMoney - journeyCost;
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {souvenierMoney:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {journeyCost - savedMoney:f2}lv. more.");
            }
        }
    }
}
