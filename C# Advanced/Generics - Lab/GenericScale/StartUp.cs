using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(5, 8);
            bool res = scale.AreEqual();
            Console.WriteLine(res);
        }
    }
}
