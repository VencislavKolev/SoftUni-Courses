
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace _1.Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>();
        private static SingletonDataContainer instance = new SingletonDataContainer();
        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");
            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                string capitalName = elements[i];
                int capitalPopulation = int.Parse(elements[i + 1]);
                capitals.Add(capitalName, capitalPopulation);
            }
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
        
        public static SingletonDataContainer Instance => instance;
    }
}
