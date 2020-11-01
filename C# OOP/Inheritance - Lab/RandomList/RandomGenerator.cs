using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomGenerator
    {
        private static readonly Random random = new Random();
        public int Next(int min,int max)
        {
            return random.Next(min, max);
        }
    }
}
