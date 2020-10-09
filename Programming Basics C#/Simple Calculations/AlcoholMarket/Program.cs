using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Моля въведете цена на уиски за един литър:");
            double whiskeyPrice = double.Parse(Console.ReadLine());
            Console.Write("Количество бира в литри:");
            double beerL = double.Parse(Console.ReadLine());
            Console.Write("Количество вино в литри:");
            double wineL = double.Parse(Console.ReadLine());
            Console.Write("Количество ракия в литри:");
            double rakiaL = double.Parse(Console.ReadLine());
            Console.Write("Количество уиски в литри:");
            double whiskeyL = double.Parse(Console.ReadLine());

            
            double rakiaPrice = whiskeyPrice / 2;
            double winePrice =rakiaPrice-(0.4*rakiaPrice);
            double beerPrice = rakiaPrice-(0.8*rakiaPrice);

            Console.WriteLine("Има се предвид че:" +
                "цената на ракията е на половина по-ниска от тази на уискито" +
                " цената на виното е с 40 % по - ниска от цената на ракията" +
                "цената на бирата е с 80 % по - ниска от цената на ракията.");

            double totalPrice = (whiskeyPrice * whiskeyL) + (beerL * beerPrice)
                + (wineL * winePrice) + (rakiaPrice * rakiaL);

            Console.WriteLine($"Общата сума е: {totalPrice:f2} лв.");
        }
    }
}
