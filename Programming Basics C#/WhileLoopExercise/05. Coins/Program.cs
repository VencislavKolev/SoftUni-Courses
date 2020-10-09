using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyInput = double.Parse(Console.ReadLine()); //13,45
            double coinsCounter = 0;
            double coins = moneyInput * 100; //1345

            while (coins >= 1)
            {
                coinsCounter++;
                if (coins >= 200)
                {
                    double num = Math.Floor(coins / 100);       //Взима 13
                    double twoCoinsCount = Math.Floor(num / 2); //Колко монети от по 2лв може да върнем за числото 13 = 6 монети*2лв.
                    double remainingCoins = num % 2;            //Остатък 1лв.

                    coinsCounter += twoCoinsCount;
                    coinsCounter--;

                    coins %= 100;                               //От 13.45лв. взимаме стотинките т.е, 45
                    coins = coins + (remainingCoins * 100);     //45+(1лв.остатък*100)=145 стотинки
                }
                else if (coins >= 100)
                {
                    coins -= 100;
                }
                else if (coins >= 50)
                {
                    coins -= 50;
                }
                else if (coins >= 20)
                {
                    coins -= 20;
                }
                else if (coins >= 10)
                {
                    coins -= 10;
                }
                else if (coins >= 5)
                {
                    coins -= 5;
                }
                else if (coins >= 2)
                {
                    coins -= 2;
                }
                else if (coins >= 1)
                {
                    coins -= 1;
                }
            }
            Console.WriteLine(coinsCounter);
        }
    }
}
