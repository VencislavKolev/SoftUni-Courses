using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> productShop =
                new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] inputInfo = input.Split(", ");
                string superMarketName = inputInfo[0];
                string product = inputInfo[1];
                double price = double.Parse(inputInfo[2]);
                if (!productShop.ContainsKey(superMarketName))
                {
                    productShop[superMarketName] = new Dictionary<string, double>();
                }
                if (!productShop[superMarketName].ContainsKey(product))
                {
                    productShop[superMarketName][product] = 0;
                }
                productShop[superMarketName][product] = price;

                input = Console.ReadLine();
            }
            foreach (var supermaket in productShop.OrderBy(x => x.Key))
            {
                Console.WriteLine(supermaket.Key + "->");
                foreach (var (productKey, priceValue) in supermaket.Value)
                {
                    Console.WriteLine($"Product: {productKey}, Price: {priceValue}");
                }
            }
        }
    }
}
