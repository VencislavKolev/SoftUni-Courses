using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double priceForFlower = 0;
            if (flowers=="Roses")
            {
                priceForFlower = 5;
            }
            else if (flowers=="Dahlias")
            {
                priceForFlower = 3.8;
            }
            else if (flowers == "Tulips")
            {
                priceForFlower = 2.8;
            }
            else if (flowers == "Narcissus")
            {
                priceForFlower = 3;
            }
            else if (flowers == "Gladiolus")
            {
                priceForFlower = 2.5;
            }

            double Sum = quantity * priceForFlower;
            
          
            if (flowers=="Roses" && quantity>80)
            {
                Sum *= 0.9;
            }
            else if (flowers == "Dahlias" && quantity > 90)
            {
                Sum *= 0.85;
            }
            else if (flowers == "Tulips" && quantity > 80)
            {
                Sum *= 0.85;
            }
            else if (flowers == "Narcissus" && quantity < 120)
            {
                Sum *= 1.15;
            }
            else if (flowers == "Gladiolus" && quantity < 80)
            {
                Sum *= 1.20;
            }
            bool isEnough = budget >= Sum;

            if (isEnough)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {flowers} and {budget-Sum:f2} leva left.");
            }
            else if (!isEnough)
            {
                Console.WriteLine($"Not enough money, you need {Sum-budget:f2} leva more.");
            }

        }
    }
}
