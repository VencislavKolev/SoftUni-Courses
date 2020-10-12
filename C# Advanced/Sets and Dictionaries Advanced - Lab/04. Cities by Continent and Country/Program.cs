using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> myWorldDict =
                new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if (!myWorldDict.ContainsKey(continent))
                {
                    myWorldDict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!myWorldDict[continent].ContainsKey(country))
                {
                    myWorldDict[continent].Add(country, new List<string>());
                }

                myWorldDict[continent][country].Add(city);

            }
            foreach (var continent in myWorldDict)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var (country, cityList) in continent.Value)
                {
                    string cities = string.Join(", ", cityList);
                    Console.WriteLine($"  {country} -> {cities}");
                }
            }
        }
    }
}
