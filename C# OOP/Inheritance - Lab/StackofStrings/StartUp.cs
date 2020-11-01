using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            set.AddRange(new[] { 2, 3, 4, 4 });
            Console.WriteLine(set.IsEmpty());
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
