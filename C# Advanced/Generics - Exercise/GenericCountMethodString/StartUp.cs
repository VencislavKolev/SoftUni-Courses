using System;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Values.Add(input);
            }
            string element = Console.ReadLine();
            int result = box.GreaterThan(element);
            Console.WriteLine(result);
        }
    }
}
