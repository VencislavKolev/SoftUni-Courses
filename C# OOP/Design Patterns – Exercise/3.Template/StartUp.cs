﻿using System;

namespace _3.Template
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();
            Console.WriteLine();
            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();
            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
