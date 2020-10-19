using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var parrots = new List<Parrot>();
            for (int i = 0; i < lines; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(", ");
                var myParrot = new Parrot
                {
                    Name = inputData[0],
                    Age = int.Parse(inputData[1])
                };
                parrots.Add(myParrot);
            }

            string conditionFilter = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            Func<Parrot, bool> myFilter = conditionFilter switch
            {
                "older" => p => p.Age >= ageFilter,
                "younger" => p => p.Age < ageFilter,
                _ => parrots => true
            };

            var outputFormat = Console.ReadLine();
            Func<Parrot, string> outputFunc = outputFormat switch
            {
                "name age" => p => $"{p.Name} - {p.Age}",
                "name" => p => $"{p.Name}",
                "age" => p => $"{p.Age}",
                _ => null
            };
            parrots
                .Where(myFilter)
                .Select(outputFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }

    }
    class Parrot
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
