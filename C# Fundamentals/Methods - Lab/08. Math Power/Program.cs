using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = MathPower(num, power);
            Console.WriteLine(result);
        }
        static double MathPower(double number, int pow)
        {
            //всяко число на степен 0 е равно на 1
            double result = 1;
            for (int i = 1; i <= pow; i++)
            {
                //умножаваме даденото числото,POW-пъти
                result *= number;
            }
            return result;
        }
    }
}
