using System;
using System.Linq;

namespace Functional_Programming___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> myAction = (name) =>
             {
                 Console.WriteLine(name);
             };
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(myAction);
            //ForEach(x=>myAction(x));
        }
    }
}
