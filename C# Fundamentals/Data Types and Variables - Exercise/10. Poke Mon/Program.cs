//using System;

//namespace _10._Poke_Mon
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int pokePower = int.Parse(Console.ReadLine()); //N
//            int distance = int.Parse(Console.ReadLine()); //M
//            byte exhaustionFactor = byte.Parse(Console.ReadLine()); //Y
//            ushort pokeCount = 0;
//            double halfInitialPokePower = pokePower / 2.0;
//            while (pokePower >= distance)
//            {
//                pokePower -= distance;
//                pokeCount++;
//                if (pokePower == halfInitialPokePower)
//                {
//                    if (exhaustionFactor != 0)
//                    {
//                        pokePower /= exhaustionFactor;
//                    }
//                }
//            }
//            Console.WriteLine(pokePower);
//            Console.WriteLine(pokeCount);
//        }
//    }
//}

using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine()); //N
            int distance = int.Parse(Console.ReadLine()); //M
            byte exhaustionFactor = byte.Parse(Console.ReadLine()); //Y
            ushort pokeCount = 0;
            double halfInitialPokePower = pokePower / 2.0;
            do
            {
                pokePower -= distance;
                pokeCount++;
                if (halfInitialPokePower == pokePower)
                {
                    if (exhaustionFactor != 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }
            } while (pokePower >= distance);
            Console.WriteLine(pokePower);
            Console.WriteLine(pokeCount);
        }
    }
}

