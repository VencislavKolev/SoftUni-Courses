using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            double finalSum = 0;
            while (action != "Start")
            {
                double insertedCoins = double.Parse(action);
                if (insertedCoins == 0.1 || insertedCoins == 0.2
                 || insertedCoins == 0.5 || insertedCoins == 1
                 || insertedCoins == 2)
                {
                    finalSum += insertedCoins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {insertedCoins}");
                }

                action = Console.ReadLine();
            }

            string product = Console.ReadLine();
            double productPrice = 0;
            double moneyLeft = finalSum;
            while (product != "End")
            {
                if (product == "Nuts")
                {
                    productPrice = 2;
                    if (moneyLeft >= productPrice)
                    {
                        moneyLeft -= productPrice;
                        Console.WriteLine($"Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Water")
                {
                    productPrice = 0.7;
                    if (moneyLeft >= productPrice)
                    {
                        moneyLeft -= productPrice;
                        Console.WriteLine($"Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Crisps")
                {
                    productPrice = 1.5;
                    if (moneyLeft >= productPrice)
                    {
                        moneyLeft -= productPrice;
                        Console.WriteLine($"Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Soda")
                {
                    productPrice = 0.8;
                    if (moneyLeft >= productPrice)
                    {
                        moneyLeft -= productPrice;
                        Console.WriteLine($"Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Coke")
                {
                    productPrice = 1;
                    if (moneyLeft >= productPrice)
                    {
                        moneyLeft -= productPrice;
                        Console.WriteLine($"Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {moneyLeft:f2}");
        }
    }
}
