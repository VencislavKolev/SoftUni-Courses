using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];
                Person person = new Person(name, age, town);
                people.Add(person);
            }
            int position = int.Parse(Console.ReadLine());
            Person personToCompare = people[position - 1];

            int matches = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    matches++;
                }
            }
            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int nonMatches = people.Count - matches;
                string output = $"{matches} {nonMatches} {people.Count}";
                Console.WriteLine(output);
            }
        }
    }
}
