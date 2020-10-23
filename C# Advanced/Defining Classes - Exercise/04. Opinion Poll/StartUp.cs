using System;
using System.Collections.Generic;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }
            HashSet<Person> result = family.GetAllPeopleAbove30();
            Console.WriteLine(string.Join(Environment.NewLine,result));
        }
    }
}
