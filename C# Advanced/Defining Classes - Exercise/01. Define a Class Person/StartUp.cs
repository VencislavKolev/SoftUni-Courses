using System;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string name = "Pesho";
            int age = 10;

            Person person = new Person
            {
                Name = name,
                Age = age
            };

            Console.WriteLine($"{person.Name} -> {person.Age}");
        }
    }
}
