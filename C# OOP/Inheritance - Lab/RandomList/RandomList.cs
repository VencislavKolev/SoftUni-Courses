using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            RandomGenerator rand = new RandomGenerator();
            int index = rand.Next(0, this.Count);
            string randomString = this[index];
            this.RemoveAt(index);
            return randomString;
        }
    }
}
