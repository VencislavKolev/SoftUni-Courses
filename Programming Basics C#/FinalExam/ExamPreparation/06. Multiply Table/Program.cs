using System;

namespace _06._Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
      
            for (int i = 1; i <= number%10; i++)
            {
                for (int j = 1; j <= number/10%10; j++)
                {
                    for (int k = 1; k <= number/100; k++)
                    {
                        int result = i * j * k;
                        Console.WriteLine($"{i} * {j} * {k} = {result};");
                    }
                }
            }
        }
    }
}
