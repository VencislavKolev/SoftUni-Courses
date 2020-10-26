using System;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Values.Add(input);
            }
            double element = double.Parse(Console.ReadLine());
            int result = box.GreaterThan(element);
            Console.WriteLine(result);
        }
    }
}
