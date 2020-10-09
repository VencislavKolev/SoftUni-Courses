using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine()) ;
     
            int j = int.Parse(Console.ReadLine());
     

            var sum = i * 2.5 + j * 4;
            Console.WriteLine($"{sum:f2} lv.");
            


        }
    }
}
