using System;

namespace _04._Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());
            for (int firstNum = 2; firstNum <= lastNumber; firstNum++)
            {
                //bool isPrime = true;
                string result = "true";
                for (int divisionNumber = 2; divisionNumber < firstNum; divisionNumber++)
                {
                    if (firstNum % divisionNumber == 0)
                    {
                        //isPrime = false;
                        result = "false";
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", firstNum, result);
            }
        }
    }
}
