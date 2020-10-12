using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbersData = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(", ");
                string action = inputArgs[0];
                string carNumber = inputArgs[1];
                if (action == "IN")
                {
                    carNumbersData.Add(carNumber);
                }
                else if (action == "OUT")
                {
                    carNumbersData.Remove(carNumber);
                }
            }
            if (carNumbersData.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, carNumbersData));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
