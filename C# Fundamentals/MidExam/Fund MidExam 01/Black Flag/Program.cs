using System;

namespace Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalDays = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;

            for (int currDay = 1; currDay <= totalDays; currDay++)
            {
                totalPlunder += dailyPlunder;
                if (currDay % 3 == 0)
                {
                    //ДА СЕ ДЕЛИ С 2.0,а не само с 2
                    totalPlunder += dailyPlunder / 2.0;
                }
                if (currDay % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }
            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {Convert.ToDecimal(totalPlunder):f2} plunder gained.");
            }
            else
            {
                decimal percentage = Convert.ToDecimal(totalPlunder / expectedPlunder * 100);
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
