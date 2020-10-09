using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputNumber = double.Parse(Console.ReadLine());
            string inputMetricUnit = Console.ReadLine();
            string outputMetricUnit = Console.ReadLine();
            double tempValueCm = inputNumber;

            if (inputMetricUnit=="mm")
            {
                tempValueCm = inputNumber / 10;
            }
            else if (inputMetricUnit=="m")
            {
                tempValueCm = inputNumber * 100;
            }
            else if (inputMetricUnit=="cm")
            {
                tempValueCm = inputNumber;
            }

            double resultValue = 0;
            if (outputMetricUnit=="mm")
            {
                resultValue = tempValueCm * 10;
            }
            else if (outputMetricUnit=="m")
            {
                resultValue = tempValueCm / 100;
            }
            else if (outputMetricUnit=="cm")
            {
                resultValue = tempValueCm;
            }
            Console.WriteLine($"{resultValue:f3}");
        }
    }
}
